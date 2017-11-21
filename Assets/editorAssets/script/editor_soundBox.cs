using UnityEngine;
using System.Collections;

public class editor_soundBox : MonoBehaviour {
    public enum soundMode{
        BGM,
        SE,
    };
    public soundMode mode;

    public enum SOUND
    {
        _null,
        BGM_1,
        BGM_2,
        BGM_3,
        BGM_4,
        BGM_5,
        SE_jump,
        SE_step,
        SE_spring,
        SE_damage,
        
    };
    public SOUND SOUNDsource;

    public bool isBGM;
    public bool isSet;

    public GameObject getItem;

    int openTime = 3;

    editor_soundManager soundManager;

    //editor_editManager editManaegr;

	// Use this for initialization
	void Start () {

        if (mode == soundMode.BGM)
        {
            isBGM = true;
        }
        else
        {
            isBGM = false;
        }
        //getItem = null;
        isSet = false;
        soundManager = GameObject.Find("editor_sideSound").GetComponent<editor_soundManager>();
        openTime = 3;
	}


    void FirstSetIn_getItemBGM(int ID)
    {
		getItem = GameObject.Find("editor_soundItem_BGM_" + ID);
        getItem.transform.position = transform.position;
        getItem.GetComponent<editor_soundItem>().setBox = this.gameObject;
        getItem.GetComponent<editor_soundItem>().isApproach = true;
        //Debug.Log(getItem.transform.name);
    }
    void FirstSetIn_getItemSE(int ID)
    {
        getItem = GameObject.Find("editor_soundItem_SE_" + ID);
        getItem.transform.position = transform.position;
        getItem.GetComponent<editor_soundItem>().setBox = this.gameObject;
        getItem.GetComponent<editor_soundItem>().isApproach = true;
        //Debug.Log(getItem.transform.name);
    }

    public void FirstSetIn()
    {
        //既にはめられていた場合
        switch (SOUNDsource)
        {
		case SOUND.BGM_1:
			if(SaveStageData.Instance.GetSelectStageData.BGMID !=-1){
				FirstSetIn_getItemBGM (SaveStageData.Instance.GetSelectStageData.BGMID);
//                if (editor_editManager.BGM_ID[0, editor_editManager.stageID] != -1)
//                {
//                    FirstSetIn_getItemBGM(0);
//                }
//                break;
//            case SOUND.BGM_2:
//                if (editor_editManager.BGM_ID[1, editor_editManager.stageID] != -1)
//                {
//                    FirstSetIn_getItemBGM(1);
//                }
//                break;
//            case SOUND.BGM_3:
//                if (editor_editManager.BGM_ID[2, editor_editManager.stageID] != -1)
//                {
//                    FirstSetIn_getItemBGM(2);
//                }
//                break;
//            case SOUND.BGM_4:
//                if (editor_editManager.BGM_ID[3, editor_editManager.stageID] != -1)
//                {
//                    FirstSetIn_getItemBGM(3);
//                }
//                break;
//            case SOUND.BGM_5:
//                if (editor_editManager.BGM_ID[4, editor_editManager.stageID] != -1)
//                {
//                    FirstSetIn_getItemBGM(4);
//                }
			}
                break;
            case SOUND.SE_jump:
			if (SaveStageData.Instance.GetSelectStageData.JumpSE != -1)
                {
				FirstSetIn_getItemSE(SaveStageData.Instance.GetSelectStageData.JumpSE);
                }
                break;
            case SOUND.SE_step:
				if (SaveStageData.Instance.GetSelectStageData.StepSE != -1)
                {
				FirstSetIn_getItemSE(SaveStageData.Instance.GetSelectStageData.StepSE);
                }
                break;
            case SOUND.SE_spring:
				if (SaveStageData.Instance.GetSelectStageData.SpringSE != -1)
                {
                    FirstSetIn_getItemSE(SaveStageData.Instance.GetSelectStageData.SpringSE);
                }
                break;
            case SOUND.SE_damage:
                if (SaveStageData.Instance.GetSelectStageData.DamageSE != -1)
                {
                    FirstSetIn_getItemSE(SaveStageData.Instance.GetSelectStageData.DamageSE);
                }
                break;
            default:
                break;
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        if (soundManager.isOpen)
        {
            if (0 < openTime)
            {
                openTime--;
            }
        }
        else
        {
            openTime = 3;
        }
        if (0 < openTime)
        {
            return;
        }
        if (getItem != null)
        {
            switch (SOUNDsource)
            {
                case SOUND.BGM_1:
                    SaveStageData.Instance.GetSelectStageData.BGMID = getItem.GetComponent<editor_soundItem>().ID;
                    //editor_editManager.BGM = getItem.GetComponent<AudioSource>();
                    break;
//                case SOUND.BGM_2:
//                    editor_editManager.BGM_ID[1, editor_editManager.stageID] = getItem.GetComponent<editor_soundItem>().ID;
//                    //editor_editManager.BGM = getItem.GetComponent<AudioSource>();
//                    break;
//                case SOUND.BGM_3:
//                    editor_editManager.BGM_ID[2, editor_editManager.stageID] = getItem.GetComponent<editor_soundItem>().ID;
//                    //editor_editManager.BGM = getItem.GetComponent<AudioSource>();
//                    break;
//                case SOUND.BGM_4:
//                    editor_editManager.BGM_ID[3, editor_editManager.stageID] = getItem.GetComponent<editor_soundItem>().ID;
//                    //editor_editManager.BGM = getItem.GetComponent<AudioSource>();
//                    break;
//                case SOUND.BGM_5:
//                    editor_editManager.BGM_ID[4, editor_editManager.stageID] = getItem.GetComponent<editor_soundItem>().ID;
//                    //editor_editManager.BGM = getItem.GetComponent<AudioSource>();
//                    break;
                case SOUND.SE_jump:
                    //editor_editManager.SE_jump = getItem.GetComponent<AudioSource>();
                    SaveStageData.Instance.GetSelectStageData.JumpSE = getItem.GetComponent<editor_soundItem>().ID;
                    break;
                case SOUND.SE_step:
                    //editor_editManager.SE_step = getItem.GetComponent<AudioSource>();
					SaveStageData.Instance.GetSelectStageData.StepSE = getItem.GetComponent<editor_soundItem>().ID;
                    break;
                case SOUND.SE_spring:
                    //editor_editManager.SE_spring = getItem.GetComponent<AudioSource>();
					SaveStageData.Instance.GetSelectStageData.SpringSE = getItem.GetComponent<editor_soundItem>().ID;
                    break;
                case SOUND.SE_damage:
                    //editor_editManager.SE_damage = getItem.GetComponent<AudioSource>();
					SaveStageData.Instance.GetSelectStageData.DamageSE = getItem.GetComponent<editor_soundItem>().ID;
                    break;
                default:
                    break;
            }

        }
        else
        {
            switch (SOUNDsource)
            {
                case SOUND.BGM_1:
					SaveStageData.Instance.GetSelectStageData.BGMID = -1;
                    break;
//                case SOUND.BGM_2:
//                    editor_editManager.BGM_ID[1, editor_editManager.stageID] = -1;
//                    break;
//                case SOUND.BGM_3:
//                    editor_editManager.BGM_ID[2, editor_editManager.stageID] = -1;
//                    break;
//                case SOUND.BGM_4:
//                    editor_editManager.BGM_ID[3, editor_editManager.stageID] = -1;
//                    break;
//                case SOUND.BGM_5:
//                    editor_editManager.BGM_ID[4, editor_editManager.stageID] = -1;
//                    break;
			case SOUND.SE_jump:
				//editor_editManager.SE_jump = getItem.GetComponent<AudioSource>();
				SaveStageData.Instance.GetSelectStageData.JumpSE = -1;
				break;
			case SOUND.SE_step:
				//editor_editManager.SE_step = getItem.GetComponent<AudioSource>();
				SaveStageData.Instance.GetSelectStageData.StepSE = -1;
				break;
			case SOUND.SE_spring:
				//editor_editManager.SE_spring = getItem.GetComponent<AudioSource>();
				SaveStageData.Instance.GetSelectStageData.SpringSE = -1;
				break;
			case SOUND.SE_damage:
				//editor_editManager.SE_damage = getItem.GetComponent<AudioSource>();
				SaveStageData.Instance.GetSelectStageData.DamageSE = -1;
				break;
                default:
                    break;
            }
        }

    }
}
