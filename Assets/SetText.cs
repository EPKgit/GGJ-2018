using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetText : MonoBehaviour {

	private Slider slider;
	private Text text;

	void Start()
	{
		slider = GetComponent<Slider>();
		text = GetComponent<Text>();
	}
	public void updateText(Slider slider)
	{
		text.text = ((int)(slider.value*100)).ToString();
		MenuManager.instance.volume = slider.value;
	}
}
