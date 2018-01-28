using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
	public float movementSpeed;
	public float jumpForce;
    public float friction;

	private Rigidbody2D rb;
    private CapsuleCollider2D collider2D;
    private bool isGrounded = true;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<CapsuleCollider2D>();
	}

	void Update () 
	{
		float moveHorizontal = Input.GetAxisRaw("Horizontal");

        if (!Mathf.Approximately(moveHorizontal, 0f))
            rb.velocity = new Vector2(moveHorizontal > 0 ? movementSpeed : -movementSpeed, rb.velocity.y);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
		{
			rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
		}

        if (!isGrounded)
        {
            Vector2 botPos = collider2D.bounds.ClosestPoint((Vector2)transform.position + Vector2.down*100);
            RaycastHit2D temp = Physics2D.Raycast(botPos, Vector2.down, 0.15f, ~LayerMask.GetMask("Player"));
            if(temp.collider != null)
                isGrounded = true;
        }

	}
}
