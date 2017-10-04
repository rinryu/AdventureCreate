using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class audio_button : MonoBehaviour {

    int count = 0;
    public Sprite on;
    public Sprite off;
    // Use this for initialization
    void Start () {
        count = 0;
	}

    // Update is called once per frame
    void Update()
    {
        if (Application.loadedLevelName == "titleScene")
        {
            if (count % 2 != 0)
            {
                GameObject.Find("titleCamera").GetComponent<AudioSource>().volume = 0;
                GameObject.Find("audio_button").GetComponent<Image>().sprite = off;
            }
            else
            {
                GameObject.Find("titleCamera").GetComponent<AudioSource>().volume = 1;
                GameObject.Find("audio_button").GetComponent<Image>().sprite = on;
            }
        }
        else if (Application.loadedLevelName == "gameScene")
        {
            if (count % 2 != 0)
            {
                GameObject.Find("BGM").GetComponent<AudioSource>().volume = 0;
                GameObject.Find("audio_button").GetComponent<Image>().sprite = off;
            }
            else
            {
                GameObject.Find("BGM").GetComponent<AudioSource>().volume = 1;
                GameObject.Find("audio_button").GetComponent<Image>().sprite = on;
            }
        }
    }

    public void click()
    {
        count++;
    }
}
