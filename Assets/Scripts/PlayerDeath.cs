using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerDeath : MonoBehaviour 
{

	public Checkpoint lastCheckpoint;
	public GameObject deathScreen;

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
			DisplayDeathScreen();
	}

	void DisplayDeathScreen()
	{
		deathScreen.SetActive(true);
		//PlayerMovement.hasControl = false;
		Time.timeScale = 0;
	}

	public void Respawn()
	{
		deathScreen.SetActive(false);
		//PlayerMovement.hasControl = true;
		Time.timeScale = 1;
		transform.position = lastCheckpoint.positionToReturnTo;
	}


}
