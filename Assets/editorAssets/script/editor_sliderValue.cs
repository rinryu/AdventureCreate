using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class editor_sliderValue : MonoBehaviour {
    Image image;
    public Slider value_slider;
    int ID;
    public Sprite[] font = new Sprite[10];

	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        image.sprite = font[(int)value_slider.value];
	}
}
