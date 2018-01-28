using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeBox : MonoBehaviour {

    //public bool modfirstAudSource;
    public float audioFadeAmount;
    public float newVolume;
    public string trackLayerName;
    private AudioSource audSou;
    private bool hasAlreadyActivated = false;

    void Start()
    {
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Collision Detected!");
        if (!hasAlreadyActivated && other.gameObject.tag == "Player")
        {
            audSou = other.transform.Find(trackLayerName).GetComponent<AudioSource>();
            StartCoroutine("FadeIn");
            hasAlreadyActivated = true;
        }
    }
    IEnumerator FadeIn()
    {
        do
        {
            audSou.volume += audioFadeAmount;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            //only increments once every 5 ticks b/c its far too fast otherwise
        } while (audSou.volume + audioFadeAmount < newVolume);
        audSou.volume = newVolume;
    }
}
