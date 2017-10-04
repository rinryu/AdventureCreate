using UnityEngine;
using System.Collections;

public class Cursor_on : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CursorEnter()
    {
        Debug.Log("in");
        gameObject.transform.FindChild("Image").gameObject.SetActive(true);
        
    }
    public void CursorExit()
    {
        Debug.Log("out");
        gameObject.transform.FindChild("Image").gameObject.SetActive(false);
    }
}
