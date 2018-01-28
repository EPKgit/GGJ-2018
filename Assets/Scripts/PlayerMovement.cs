using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour 
{
    public static bool hasControl;

	public float movementSpeed;
	public float jumpForce;
    public float friction;
    public GameObject childImageRenderer;
    public GameObject pauseScreen;

	private Rigidbody2D rb;
    private CapsuleCollider2D collider2D;
    private bool isGrounded = true;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<CapsuleCollider2D>();
        hasControl = true;
	}

	void Update () 
	{
        if(!hasControl)
            return;

        if(Input.GetKeyDown(KeyCode.Escape))
            openPauseMenu();
		float moveHorizontal = Input.GetAxisRaw("Horizontal");

        if (!Mathf.Approximately(moveHorizontal, 0f)) {
            rb.velocity = new Vector2(moveHorizontal > 0 ? movementSpeed : -movementSpeed, rb.velocity.y);
            if (rb.velocity.x > 0)
            {
                childImageRenderer.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                childImageRenderer.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
            

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
		{
            rb.velocity = new Vector2(rb.velocity.x, 0f);
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

    public void openPauseMenu()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void closePauseMenu()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }

    public void returnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void quit()
    {
        Application.Quit();
    }
}
