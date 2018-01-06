using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour {

    public sceneChangeManager sceneChange;

	// Use this for initialization
	void Start () {
        sceneChange.LoadScene();
        SaveStageData.Instance.GetAllStageCoroutine();

    }

    // Update is called once per frame
    void Update () {
		
	}
}
