using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

	void OnCollisionEnter2D(Collider2D col)
	{
		SceneManager.LoadScene("EndGame");
	}
}
