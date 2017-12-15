using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour {

    public sceneChangeManager sceneChange;

	// Use this for initialization
	void Start () {
        sceneChange.LoadScene();
		if(UserData.Instanse.username != null) SaveStageData.Instance.GetStageCoroutine();

    }

    // Update is called once per frame
    void Update () {
		
	}
}
