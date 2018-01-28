using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour 
{
	public enum dir { up = 0, down, left, right };
	public dir directionToMove;
	public float speed;
	public float killthreshold;

	private Vector2 direction;
	private Rigidbody2D rigidbody;
	private BoxCollider2D collider2D;
	private bool moving;

	void Start () 
	{
		switch((int)directionToMove)
		{
			case 0:
			{
				direction = new Vector2(0,1);
			} break;
			case 1:
			{
				direction = new Vector2(0,-1);
			} break;
			case 2:
			{
				direction = new Vector2(-1,0);
			} break;
			case 3:
			{
				direction = new Vector2(1,0);
			} break;
		}
		moving = false;
		collider2D = GetComponent<BoxCollider2D>();
		rigidbody = GetComponent<Rigidbody2D>();
	}
	
	void Update () 
	{
		if(moving)
			return;
		Vector2 pos = collider2D.bounds.ClosestPoint((Vector2)transform.position + direction*100);
        RaycastHit2D temp = Physics2D.Raycast(pos, direction, Mathf.Infinity, ~LayerMask.GetMask("Crusher"));
		if(temp.collider != null && temp.collider.gameObject.CompareTag("Player"))
			StartCoroutine(Movement());

	}

	IEnumerator Movement()
	{
		moving = true;
		do
		{
			rigidbody.velocity = direction*speed;
			yield return null;
		} while(rigidbody.velocity != Vector2.zero);
		do
		{
			rigidbody.velocity = -direction*speed*3;
			yield return null;
		} while(rigidbody.velocity != Vector2.zero);
		moving = false;
	}

	void OnCollisionStay2D(Collision2D col)
	{
		if(!col.gameObject.CompareTag("Player"))
			return;
		Debug.Log("staying");
		Vector2 myPos = collider2D.bounds.ClosestPoint((Vector2)transform.position + direction*100);
		Vector2 oPos = col.collider.bounds.ClosestPoint((Vector2)col.gameObject.transform.position + -direction*100);
		PlayerDeath player = col.collider.gameObject.GetComponent<PlayerDeath>();
		Debug.Log("my" + myPos);
		Debug.Log("player" + oPos);
		switch((int)directionToMove)
		{
			case 0:
			{
				if(Mathf.Abs(myPos.y - oPos.y) > killthreshold)
					player.Kill();
			} break;
			case 1:
			{
				if(Mathf.Abs(oPos.y - myPos.y)  > killthreshold)
					player.Kill();
			} break;
			case 2:
			{
				if(Mathf.Abs(myPos.x - oPos.x) > killthreshold)
					player.Kill();
			} break;
			case 3:
			{
				if(Mathf.Abs(oPos.x - myPos.x) > killthreshold)
					player.Kill();
			} break;
		}
	}

}
