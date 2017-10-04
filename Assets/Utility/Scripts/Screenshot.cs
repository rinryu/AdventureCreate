using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Screenshot : MonoBehaviour {

    public KeyCode screenshotkey;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(screenshotkey))
        {
            TakeShot();
        }
		
	}

    void TakeShot()
    {
        Application.CaptureScreenshot(Application.dataPath + "/Utility/ScreenShot/" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png", 5);
        Debug.Log("screenshot success");
    }
}
