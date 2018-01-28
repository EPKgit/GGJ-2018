using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{

	public GameObject toFollow;
	public Vector3 offset;

	void Start () 
	{
        
		if (toFollow == null)
			toFollow = GameObject.FindGameObjectWithTag("Player");
		AudioListener.volume = MenuManager.instance.volume;
		
	}
	
	void LateUpdate () 
	{
		transform.position = toFollow.transform.position + offset;
	}
}
