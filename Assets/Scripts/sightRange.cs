using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sightRange : MonoBehaviour 
{

	private LayerMask oov;
	private LayerMask iv;

	void Awake()
	{
		oov = LayerMask.GetMask("OutOfView");
		iv = LayerMask.GetMask("InView");
		Debug.Log(oov.value + " " + iv.value);
	}
	void OnTriggerEnter2D(Collider2D other) 
	{
		Debug.Log("enter " + other.gameObject.layer);
		if(other.gameObject.layer == oov)
		{
			Debug.Log("revealing " + other.gameObject.name);
			other.gameObject.layer = iv;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.layer == iv)
		{
			Debug.Log("hiding " + other.gameObject.name);
			other.gameObject.layer = oov;
		}
	}
}
