using UnityEngine;
using System.Collections;

public class sc : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            shot();
        }

	}

    void shot()
    {
        Debug.Log(Application.dataPath);
        string time;
        time = System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + "-" + System.DateTime.Now.Hour.ToString() + "-" + System.DateTime.Now.Minute.ToString() + "-" + System.DateTime.Now.Second.ToString();
        Application.CaptureScreenshot(Application.dataPath+"/"+time+".png");
    }

}
