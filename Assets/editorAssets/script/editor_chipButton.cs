using UnityEngine;
using System.Collections;

public class editor_chipButton : MonoBehaviour {
    GameObject select;
    editor_editManager manager;
    public enum chipName
    {
        _null,
        _stage,
        _toge,
        _spring,
        _goalFlag,
        _player,
        _enemyA,
        _enemyB_0,
        _enemyB_1,
        _flower,
    }
    public chipName chipNameMode;

	// Use this for initialization
	void Start () {
        manager = GameObject.Find("EditManager").GetComponent<editor_editManager>();
        select = GameObject.Find("chipButton_select");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Push()
    {
        //transform.parent = select.transform;
        select.gameObject.GetComponent<Animator>().Play("chipButtonSelect_push");
        select.transform.localPosition = transform.localPosition;
        switch (chipNameMode)
        {
            case chipName._null:
                manager.setMapChipID = 0;
                break;
            case chipName._stage:
                manager.setMapChipID = 1;
                break;
            case chipName._toge:
                manager.setMapChipID = 2;
                break;
            case chipName._spring:
                manager.setMapChipID = 3;
                break;
            case chipName._goalFlag:
                manager.setMapChipID = 4;
                break;
            case chipName._player:
                manager.setMapChipID = 5;
                break;
            case chipName._enemyA:
                manager.setMapChipID = 6;
                break;
            case chipName._enemyB_0:
                manager.setMapChipID = 7;
                break;
            case chipName._enemyB_1:
                manager.setMapChipID = 8;
                break;
            case chipName._flower:
                manager.setMapChipID = 9;
                break;
            default:
                break;
        }
        
        
    }
}
