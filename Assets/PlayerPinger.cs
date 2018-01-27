using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPinger : MonoBehaviour 
{
	public GameObject ping;	
	public float speed;

	public static List<CircleCollider2D> instantiated = new List<CircleCollider2D>();

	private BoxCollider2D box;

	void Start()
	{
		box = GetComponent<BoxCollider2D>();
	}

	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			Vector3 mouse = Input.mousePosition;
			mouse.z = -2;
			Vector3 direction = (Camera.main.ScreenToWorldPoint(mouse) - transform.position).normalized;

			GameObject proj = Instantiate(ping, transform.position, Quaternion.identity);
			CircleCollider2D col = proj.GetComponent<CircleCollider2D>();
			Physics2D.IgnoreCollision(col, box);
			for(int x = 0; x < instantiated.Count; x++)
				Physics2D.IgnoreCollision(instantiated[x], col);
			proj.GetComponent<Rigidbody2D>().velocity = -direction * speed;
		}
	}
}
