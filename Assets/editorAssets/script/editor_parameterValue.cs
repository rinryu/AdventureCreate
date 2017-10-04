using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class editor_parameterValue : MonoBehaviour {
    //editor_editManager editManager;
    public int parameterID;
    Slider slider;
    bool load = false;
	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
        //editManager = GameObject.Find("EditManager").GetComponent<editor_editManager>();
        slider.value = editor_editManager.value[parameterID,editor_editManager.stageID];
	}
	
	// Update is called once per frame
	void Update () {
        if (!load)
        {
            slider = GetComponent<Slider>();
            slider.value = editor_editManager.value[parameterID, editor_editManager.stageID];
            load = true;
        }
        editor_editManager.value[parameterID, editor_editManager.stageID] = (int)slider.value;
    }

    public void SendValue()
    {
        //editor_editManager.value[parameterID] = (int)slider.value;
    }
}
