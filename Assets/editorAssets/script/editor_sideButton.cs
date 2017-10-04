using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class editor_sideButton : MonoBehaviour {
    public Sprite play, parameter, sound, option, push;
    GameObject[] sideButton = new GameObject[4];
    Image[] sideButton_image = new Image[4];
	// Use this for initialization
	void Start () {
        sideButton[0] = transform.FindChild("play").gameObject;
        sideButton[1] = transform.FindChild("parameter").gameObject;
        sideButton[2] = transform.FindChild("sound").gameObject;
        sideButton[3] = transform.FindChild("back").gameObject;
        for (int i = 0; i < 4; i++)
        {
            sideButton_image[i] = sideButton[i].GetComponent<Image>();
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
