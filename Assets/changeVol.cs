using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeVol : MonoBehaviour {
	// Use this for initialization
	void Start () {
        this.gameObject.transform.Find("01_01").GetComponent<AudioSource>().volume = MenuManager.instance.volume;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
