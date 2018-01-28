using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
	public float movementSpeed;
	public float jumpForce;
    public float friction;
	private Rigidbody2D rb;
    private bool isGrounded = true;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update () 
	{
		float moveHorizontal = Input.GetAxisRaw("Horizontal");

        if (!Mathf.Approximately(moveHorizontal, 0f))
            rb.velocity = new Vector2(moveHorizontal > 0 ? movementSpeed : -movementSpeed, rb.velocity.y);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
		{
			rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //isGrounded = false;
		}

        if (isGrounded)
        {
            if (!Mathf.Approximately(rb.velocity.x, 0))
            {
                if (rb.velocity.x > 0)
                {
                    if ((rb.velocity + friction * new Vector2(-1f, 0f)).x > 0)
                    {
                        rb.velocity = rb.velocity + friction * new Vector2(-1f, 0f);
                    }
                    else
                    {
                        rb.velocity = new Vector2();
                    }
                }
                else
                {
                    if ((rb.velocity + friction * new Vector2(1f, 0f)).x < 0)
                    {
                        rb.velocity = rb.velocity + friction * new Vector2(1f, 0f);
                    }
                    else
                    {
                        rb.velocity = new Vector2();
                    }
                }
            }
        }

	}
}
