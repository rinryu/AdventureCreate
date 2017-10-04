using UnityEngine;
using System.Collections;

public class editor_selectChipFrame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Screen.width * 0.01f > Input.mousePosition.x)
        {
            transform.position = new Vector2(-Screen.height * 2, 0);
        }
        if (Screen.width * 0.7f < Input.mousePosition.x)
        {
            transform.position = new Vector2(-Screen.height * 2, 0);
        }
        if (Screen.height * 0.96f < Input.mousePosition.y)
        {
            transform.position = new Vector2(-Screen.height * 2, 0);
        }
        if (Screen.height * 0.17f > Input.mousePosition.y)
        {
            transform.position = new Vector2(-Screen.height * 2, 0);
        }

    }
}
