using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class editor_parameterValue : MonoBehaviour {
    //editor_editManager editManager;
    public int parameterID;
    Slider slider;
    bool load = false;
	// Use this for initialization
	private ParameterData param;
	void Start () {
		param = SaveStageData.Instance.GetSelectStageData.Parameter;
        slider = GetComponent<Slider>();
        //editManager = GameObject.Find("EditManager").GetComponent<editor_editManager>();
		slider.value = param.value[parameterID];
	}
	
	// Update is called once per frame
	void Update () {
        if (!load)
        {
            slider = GetComponent<Slider>();
			slider.value = param.value[parameterID];
            load = true;
        }
		param.value[parameterID] = (int)slider.value;
		SaveStageData.Instance.GetSelectStageData.Parameter = param;
    }

    public void SendValue()
    {
        //editor_editManager.value[parameterID] = (int)slider.value;
    }
}
