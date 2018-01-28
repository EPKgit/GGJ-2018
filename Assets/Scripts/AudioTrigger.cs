using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour {

    //public bool modfirstAudSource;
    public float audioFadeAmount;
    public float maxVolume;
    public AudioClip givenClip;
    public GameObject audioThing;
    //public GameObject audioThingList;
    private bool isActive, hasAlreadyActivated = false;
    private AudioSource audSou;

    void Start () {
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Collision Detected!");
        if(!hasAlreadyActivated && other.gameObject.tag == "Player")
        {
            GameObject temp = Instantiate(audioThing, other.transform);
            //audSou = modfirstAudSource ? other.gameObject.GetComponent<AudioSource>() : other.transform.Find("AudioSource").GetComponent<AudioSource>();
            audSou = temp.GetComponent<AudioSource>();
            audSou.clip = givenClip;
            audSou.Play();
            //audSou.outputAudioMixerGroup
            audSou.volume = 0;
            audSou.loop = false;
            StartCoroutine("FadeIn");
            hasAlreadyActivated = true;
        }
    }
    IEnumerator FadeIn()
    {
        do {
            audSou.volume += audioFadeAmount;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            //only increments once every 5 ticks b/c its far too fast otherwise
        } while (audSou.volume + audioFadeAmount < maxVolume);
        audSou.volume = maxVolume;
    }
}
