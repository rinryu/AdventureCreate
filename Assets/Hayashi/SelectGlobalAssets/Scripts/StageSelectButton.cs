using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectButton : MonoBehaviour {

    public selectGlobal_selectChipManager selectChipManager;
    public int StageID;
    StageDataClass stage;
    bool isload = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetActive(StageDataClass in_stage,int ID)
    {
        StageID = ID;
        stage = in_stage;
        //StartCoroutine(selectChipManager.streamingCreateMap(stage.CovnertStageData()));
    }

    public void LoadStage()
    {
        if (!isload)
        {
            StartCoroutine(selectChipManager.streamingCreateMap(stage.ConvertStageData()));
            isload = true;
        }
    }

}