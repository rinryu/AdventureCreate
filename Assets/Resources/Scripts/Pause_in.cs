using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pause_in : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.transform.position = new Vector3(Screen.width * 10, Screen.height * 10);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (GameParameter.isMenu) {
            gameObject.transform.position = new Vector2(Screen.width/2,Screen.height/2);
        }
        else
        {
            gameObject.transform.position = new Vector3(Screen.width * 10, Screen.height *10);
        }
	}

    public void Back_Click()
    {
        GameParameter.isMenu = false;
		if (GameParameter.instance.isGlobal) {
			GetAllStageData.Instance.GetSelectStageData.missCount++;
			GetAllStageData.Instance.SendCouneter (() => {Application.LoadLevel ("selectGlobalScene");});
		}
		else if (GameParameter.instance.isEdit)
        {
            Application.LoadLevel("editorScene");
        }
        else
        {
            Application.LoadLevel("selectScene");
        }
    }
    public void Return_Click()
    {
        GameParameter.isMenu = false;
		if (GameParameter.instance.isGlobal) {
//			GameParameter.instance.isGlobal = false;
			Application.LoadLevel ("gameGlobalScene");
		}
        else Application.LoadLevel("gameScene");
    }
}
