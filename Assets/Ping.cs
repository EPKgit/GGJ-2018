using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ping : MonoBehaviour 
{
	public float maxTime;
	public LayerMask oov;

	private float remainingTime;
	private Rigidbody2D rb;
	private CircleCollider2D collider2D;
	
	void Start () 
	{
		remainingTime = maxTime;
		oov = 8;
		rb = GetComponent<Rigidbody2D>();
		collider2D = GetComponent<CircleCollider2D>();
		PlayerPinger.instantiated.Add(collider2D);
	}
	
	void Update () 
	{
		remainingTime -= Time.deltaTime;
		if(remainingTime <= 0)
			Destroy(this.gameObject);
	}

	void OnCollisionEnter2D(Collision2D other) 
	{
		if(other.gameObject.layer == oov)
			Destroy(rb);
	}

	void OnDestroy()
	{
		PlayerPinger.instantiated.Remove(collider2D);
	}
}
