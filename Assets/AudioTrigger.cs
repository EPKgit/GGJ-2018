using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour {

    public float audioFadeAmount;
    public GameObject audioThing;
    public GameObject audioThingList;
    private bool isActive;
    private AudioSource audSou;

    void Start () {
        isActive = audioThing && audioThing.GetComponent<AudioSource>();
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (isActive)
        {
            GameObject temp = Instantiate(audioThing, audioThingList.transform);
            audSou = temp.GetComponent<AudioSource>();
            audSou.volume = 0;
            StartCoroutine("fadeIn");
        }
    }
    IEnumerator fadeIn()
    {
        do {
            audSou.volume += audioFadeAmount;
            yield return null;
        } while (audSou.volume + audioFadeAmount < 1);
        audSou.volume = 1;
    }
}
