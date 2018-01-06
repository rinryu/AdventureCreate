using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplicatePanelManager : MonoBehaviour {

    [SerializeField]
    sceneChangeManager scenechangemanager;
    [SerializeField]
    editor_mapChipFrame mapchipframe;
	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenDeplicatePanel()
    {
        gameObject.SetActive(true);
    }

    public void CloseDeplicatePanel()
    {
        gameObject.SetActive(false);
    }

    public void OnPushButton(int number)
    {
        scenechangemanager.CloseScene();
        SaveStageData.Instance.OverrideStageCoroutine(SaveStageData.Instance.stageID, number,()=>
        {
            mapchipframe.InitMap(true,number);
        });
    }
}
