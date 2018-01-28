using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour 
{
	public static MenuManager instance;
	public GameObject SettingsMenu;
	public GameObject MainMenu;

	public string sceneName;
	public float volume;

	public void Awake()
	{
		if(instance != null)
			Destroy(this.gameObject);
		instance = this;
		DontDestroyOnLoad(gameObject);
	}

	public void StartGame()
	{
		SceneManager.LoadScene(sceneName);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void OpenSettingsMenu()
	{
		MainMenu.SetActive(false);
		SettingsMenu.SetActive(true);
	}

	public void CloseSettingsMenu()
	{
		MainMenu.SetActive(true);
		SettingsMenu.SetActive(false);
	}
}
