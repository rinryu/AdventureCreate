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
		param = SaveStageData.Instance.GetSelectStageData.parameterData;
        slider = GetComponent<Slider>();
        //editManager = GameObject.Find("EditManager").GetComponent<editor_editManager>();
		switch (parameterID) {
		case 0:
			slider.value = SaveStageData.Instance.GetSelectStageData.Speed;
			break;
		case 1:
			slider.value = SaveStageData.Instance.GetSelectStageData.Jump;
			break;
		case 2:
			slider.value = SaveStageData.Instance.GetSelectStageData.Life;
			break;
		case 3:
			slider.value = SaveStageData.Instance.GetSelectStageData.Gravity;
			break;

		}
//		slider.value = param.value[parameterID];
	}
	
	// Update is called once per frame
	void Update () {
		switch (parameterID) {
		case 0:
			SaveStageData.Instance.GetSelectStageData.Speed = (int)slider.value;
			break;
		case 1:
			SaveStageData.Instance.GetSelectStageData.Jump = (int)slider.value;
			break;
		case 2:
			SaveStageData.Instance.GetSelectStageData.Life = (int)slider.value;
			break;
		case 3:
			SaveStageData.Instance.GetSelectStageData.Gravity = (int)slider.value;
			break;

		}

//		param.value[parameterID] = (int)slider.value;

    }

    public void SendValue()
    {
        //editor_editManager.value[parameterID] = (int)slider.value;
    }
}
