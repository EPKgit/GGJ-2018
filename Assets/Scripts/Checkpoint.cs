using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	public Vector3 positionToReturnTo;
	public Vector3 offset;

	void Awake()
	{
		positionToReturnTo = transform.position + offset;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log("enter");
		if(col.gameObject.CompareTag("Player"))
			col.gameObject.GetComponent<PlayerDeath>().lastCheckpoint = this;
	}
}
