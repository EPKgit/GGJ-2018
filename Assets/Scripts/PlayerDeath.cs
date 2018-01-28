using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerDeath : MonoBehaviour 
{

	public Checkpoint lastCheckpoint;

	public bool testKill;


	void Update()
	{
		if(testKill)
		{
			testKill = false;
			Kill();
		}
	}
	public void Kill()
	{
		if(lastCheckpoint == null)
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		else
		{
			DisplayDeathScreen();
			Invoke("PlayerTeleport", 2f);
		}
	}

	void DisplayDeathScreen()
	{

	}

	void PlayerTeleport()
	{
		transform.position = lastCheckpoint.positionToReturnTo;
	}


}
