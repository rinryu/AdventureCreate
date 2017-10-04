using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonCLickGlobal : MonoBehaviour {

    StageGlobalButton_Controller manager;
    // Use this for initialization
    void Start()
    {
        manager = GameObject.Find("stageButtonSset").GetComponent<StageGlobalButton_Controller>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PushButton()
    {
        if (!manager.isSelect)
        {
            GameObject.Find("sceneChangeManager").GetComponent<sceneChangeManager>().ChangeScene("titleScene");
        }
        else
        {
            GameObject.Find("stageButtonSset").GetComponent<StageGlobalButton_Controller>().CloseStageButton();
        }
    }
}
