using UnityEngine;
using System.Collections;

public class selectBackButton : MonoBehaviour {
    stageButtonSset manager;
	// Use this for initialization
	void Start () {
        manager = GameObject.Find("stageButtonSset").GetComponent<stageButtonSset>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PushButton()
    {
        Debug.Log("aaa");
        Debug.Log(manager.isSelect);
        if (!manager.isSelect)
        {
            GameObject.Find("sceneChangeManager").GetComponent<sceneChangeManager>().ChangeScene("titleScene");
        }
        else
        {
            GameObject.Find("stageButtonSset").GetComponent<stageButtonSset>().CloseStageButton();
        }
    }
}
