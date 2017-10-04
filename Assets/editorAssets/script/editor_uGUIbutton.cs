using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class editor_uGUIbutton : MonoBehaviour {
    public Sprite button,pushButton;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Push()
    {
        GetComponent<Image>().sprite = pushButton;
    }
}
