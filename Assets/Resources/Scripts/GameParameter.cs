using UnityEngine;
using System.Collections;

public class GameParameter : MonoBehaviour {

	private static GameParameter _instance;
	private GameParameter(){
		Debug.Log ("CreateAssetMenuAttribute instance GameParameter");
	}
	public static GameParameter instance{
		get{
			if (_instance == null) {
				GameObject obj = new GameObject ("GameParater");
				_instance = obj.AddComponent<GameParameter> ();
			}
			return _instance;
		}
	}

    public static bool isEdit = false;
    public static bool isGlobal = false;


    enum Parameter
    {
        Min = -2,
        ThreeQuarter = -1,
        Normal = 0,
        FiveQuarter = 1,
        Max = 2
    }
    [SerializeField]
	Parameter spd = Parameter.Normal;
	public float _SPD{
		get{
			switch (spd)
			{
			case Parameter.Min:
				return 0.5f;
			case Parameter.ThreeQuarter:
				return 0.75f;
			case Parameter.Normal:
				return 1f;
			case Parameter.FiveQuarter:
				return 1.25f;
			case Parameter.Max:
				return 1.5f;
			default :
				return 1f;
			}
		}
	}

	[SerializeField]
	Parameter jmp;
	public float _JMP{
		get{
			switch (jmp)
			{
			case Parameter.Min:
				return 0.5f;
			case Parameter.ThreeQuarter:
				return 0.75f;
			case Parameter.Normal:
				return 1f;
			case Parameter.FiveQuarter:
				return 1.25f;
			case Parameter.Max:
				return 1.5f;
			default:
				return 1f;
			}
		}
	}


    [SerializeField]
	Parameter grv;
	public float _GRV{
		get{
			switch (spd)
			{
			case Parameter.Min:
				return 0.5f;
			case Parameter.ThreeQuarter:
				return 0.75f;
			case Parameter.Normal:
				return 1f;
			case Parameter.FiveQuarter:
				return 1.25f;
			case Parameter.Max:
				return 1.5f;
			default :
				return 1f;
			}
		}
	}


    enum Life : int
    {
        One		= 1,
        Two		= 2,
        Three	= 3,
        Four	= 4,
        Five	= 5,
        Six		= 6,
        Seven	= 7,
        Eight	= 8
    }
    [SerializeField]
	Life life = Life.One;
	public int _LIFE {
		get {
			switch (life)
			{
			case Life.One:
				return 1;
			case Life.Two:
				return 2;
			case Life.Three:
				return 3;
			case Life.Four:
				return 4;
			case Life.Five:
				return 5;
			case Life.Six:
				return 6;
			case Life.Seven:
				return 7;
			case Life.Eight:
				return 8;
			default:
				return 1;
			}

		}
	}
	public int Bgm_ID;
	public int[] Se_ID;

    [SerializeField]
    public AudioClip BGM;
    [SerializeField]
    public AudioClip JumpSE;
    [SerializeField]
    public AudioClip StepSE;
    [SerializeField]
    public AudioClip SpringSE;
    [SerializeField]
    public AudioClip DamageSE;
    [SerializeField]
    public AudioClip aSE;
    [SerializeField]
    public AudioClip bSE;

    public int goalEffectID;
    public int DamageEffectID;
    public int AttackEffectID;

    bool gameScene_set = false;

    public static bool isMenu = false;

    // Use this for initialization
    void Start() {
        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update() {

        if(Application.loadedLevelName == "selectScene")
        {
            GameParameter.isEdit = false;
            GameParameter.isGlobal = false;
        }else if (Application.loadedLevelName == "editorScene")
        {
            GameParameter.isEdit = true;
            GameParameter.isGlobal = false;
        }else if (Application.loadedLevelName == "selectGlobalScene")
        {
            GameParameter.isGlobal = true;
        }else if (Application.loadedLevelName == "gameScene" || Application.loadedLevelName == "gameGlobalScene")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Chara_Move cm = GameObject.Find("player(Clone)").GetComponent<Chara_Move>();
                if (cm.GetisClear() || cm.GetisGameOver()) return;
                if (!isMenu) isMenu = true;
                else isMenu = false;
            }
        }      
    }

//    void SetSpeed()
//    {
//        //Speed
//        switch (editor_editManager.value[0, editor_editManager.stageID])
//        {
//            case -2:
//                spd = Parameter.Min;
//                _SPD = 0.5f;
//                break;
//            case -1:
//                spd = Parameter.ThreeQuarter;
//                _SPD = 0.75f;
//                break;
//            case 0:
//                spd = Parameter.Normal;
//                _SPD = 1f;
//                break;
//            case 1:
//                spd = Parameter.FiveQuarter;
//                _SPD = 1.25f;
//                break;
//            case 2:
//                spd = Parameter.Max;
//                _SPD = 1.5f;
//                break;
//        }
//    }
//
//    void SetJump()
//    {
//        //Jump
//        switch (editor_editManager.value[1, editor_editManager.stageID])
//        {
//            case -2:
//                jmp = Parameter.Min;
//                _JMP = 0.5f;
//                break;
//            case -1:
//                jmp = Parameter.ThreeQuarter;
//                _JMP = 0.75f;
//                break;
//            case 0:
//                jmp = Parameter.Normal;
//                _JMP = 1f;
//                break;
//            case 1:
//                jmp = Parameter.FiveQuarter;
//                _JMP = 1.25f;
//                break;
//            case 2:
//                jmp = Parameter.Max;
//                _JMP = 1.5f;
//                break;
//        }
//    }
//
//    void SetGravity()
//    {
//        //Gravity
//        switch (editor_editManager.value[3, editor_editManager.stageID])
//        {
//            case -2:
//                grv = Parameter.Min;
//                _GRV = 0.5f;
//                break;
//            case -1:
//                grv = Parameter.ThreeQuarter;
//                _GRV = 0.25f;
//                break;
//            case 0:
//                grv = Parameter.Normal;
//                _GRV = 1f;
//                break;
//            case 1:
//                grv = Parameter.FiveQuarter;
//                _GRV = 1.25f;
//                break;
//            case 2:
//                grv = Parameter.Max;
//                _GRV = 1.5f;
//                break;
//        }
//    }
//
//    void SetLife()
//    {
//        switch (editor_editManager.value[2, editor_editManager.stageID])
//        {
//            case 1:
//                life = Life.One;
//                _LIFE = 1;
//                break;
//            case 2:
//                life = Life.Two;
//                _LIFE = 2;
//                break;
//            case 3:
//                life = Life.Three;
//                _LIFE = 3;
//                break;
//            case 4:
//                life = Life.Four;
//                _LIFE = 4;
//                break;
//            case 5:
//                life = Life.Five;
//                _LIFE = 5;
//                break;
//            case 6:
//                life = Life.Six;
//                _LIFE = 6;
//                break;
//            case 7:
//                life = Life.Seven;
//                _LIFE = 7;
//                break;
//            case 8:
//                life = Life.Eight;
//                _LIFE = 8;
//                break;
//
//            default:
//                life = Life.One;
//                _LIFE = 1;
//                break;
//        }
//    }
//
//    void SetSound()
//    {		
//        //Debug.Log(editor_editManager.stageID);
//        BGM = Resources.Load<AudioClip>("Sound/BGM_" + editor_editManager.BGM_ID[0,editor_editManager.stageID].ToString());
//        JumpSE = Resources.Load<AudioClip>("Sound/SE_"+ editor_editManager.SE_ID[0, editor_editManager.stageID].ToString());
//        StepSE = Resources.Load<AudioClip>("Sound/SE_" + editor_editManager.SE_ID[1, editor_editManager.stageID].ToString());
//        SpringSE = Resources.Load<AudioClip>("Sound/SE_" + editor_editManager.SE_ID[2, editor_editManager.stageID].ToString());
//        DamageSE = Resources.Load<AudioClip>("Sound/SE_" + editor_editManager.SE_ID[3, editor_editManager.stageID].ToString());
//        aSE = Resources.Load<AudioClip>("Sound/SE_" + editor_editManager.SE_ID[4,editor_editManager.stageID].ToString());
//        bSE = Resources.Load<AudioClip>("Sound/SE_" + editor_editManager.SE_ID[5, editor_editManager.stageID].ToString());
//    }

//    void SetSpeed(int in_speed)
//    {
//        //Speed
//    }
//
//    void SetJump(int in_jump)
//    {
//        //Jump
//        switch (in_jump)
//        {
//            case -2:
//                jmp = Parameter.Min;
//                _JMP = 0.5f;
//                break;
//            case -1:
//                jmp = Parameter.ThreeQuarter;
//                _JMP = 0.75f;
//                break;
//            case 0:
//                jmp = Parameter.Normal;
//                _JMP = 1f;
//                break;
//            case 1:
//                jmp = Parameter.FiveQuarter;
//                _JMP = 1.25f;
//                break;
//            case 2:
//                jmp = Parameter.Max;
//                _JMP = 1.5f;
//                break;
//        }
//    }
//
//    void SetGravity(int in_gravity)
//    {
//        //Gravity
//        switch (in_gravity)
//        {
//            case -2:
//                grv = Parameter.Min;
//                _GRV = 0.5f;
//                break;
//            case -1:
//                grv = Parameter.ThreeQuarter;
//                _GRV = 0.25f;
//                break;
//            case 0:
//                grv = Parameter.Normal;
//                _GRV = 1f;
//                break;
//            case 1:
//                grv = Parameter.FiveQuarter;
//                _GRV = 1.25f;
//                break;
//            case 2:
//                grv = Parameter.Max;
//                _GRV = 1.5f;
//                break;
//        }
//    }
//
//    void SetLife(int in_life)
//    {
//        switch (in_life)
//        {
//            case 1:
//                life = Life.One;
//                _LIFE = 1;
//                break;
//            case 2:
//                life = Life.Two;
//                _LIFE = 2;
//                break;
//            case 3:
//                life = Life.Three;
//                _LIFE = 3;
//                break;
//            case 4:
//                life = Life.Four;
//                _LIFE = 4;
//                break;
//            case 5:
//                life = Life.Five;
//                _LIFE = 5;
//                break;
//            case 6:
//                life = Life.Six;
//                _LIFE = 6;
//                break;
//            case 7:
//                life = Life.Seven;
//                _LIFE = 7;
//                break;
//            case 8:
//                life = Life.Eight;
//                _LIFE = 8;
//                break;
//
//            default:
//                life = Life.One;
//                _LIFE = 1;
//                break;
//        }
//    }

    void SetSound(int in_BGM,int[] in_SE)
    {
        //Debug.Log(editor_editManager.stageID);
        //Debug.Log(editor_editManager.BGM_ID[0,editor_editManager.stageID]);
		Bgm_ID = in_BGM;
		Se_ID = in_SE;
        BGM = Resources.Load<AudioClip>("Sound/BGM_" +in_BGM.ToString());
        JumpSE = Resources.Load<AudioClip>("Sound/SE_" + in_SE[0].ToString());
        StepSE = Resources.Load<AudioClip>("Sound/SE_" + in_SE[1].ToString());
        SpringSE = Resources.Load<AudioClip>("Sound/SE_" + in_SE[2].ToString());
        DamageSE = Resources.Load<AudioClip>("Sound/SE_" + in_SE[3].ToString());
        aSE = Resources.Load<AudioClip>("Sound/SE_" + in_SE[4].ToString());
        bSE = Resources.Load<AudioClip>("Sound/SE_" + in_SE[5].ToString());
    }

    void SetEffect(int[] in_effets)
    {
        goalEffectID = in_effets[0];
        DamageEffectID = in_effets[1];
        AttackEffectID = in_effets[2];
    }

    public void SetParam(ParameterData in_param)
    {
        Debug.Log("SetParam");
        Debug.Log(in_param.BGMID);
		spd = (Parameter)in_param.value [0];
		jmp = (Parameter)in_param.value [1];
		life = (Life)in_param.value [2];
		grv = (Parameter)in_param.value [3];
        SetSound(in_param.BGMID, in_param.SEID);
        SetEffect(in_param.effectID);
    }

	public ParameterData SaveParam(){
		Debug.Log ("SaveParam");
		ParameterData param = new ParameterData();
		param.value [0] = (int)spd;
		param.value [1] = (int)jmp;
		param.value [2] = (int)life;
		param.value [3] = (int)grv;
		param.BGMID = Bgm_ID;
		param.SEID = Se_ID;
		param.effectID [0] = goalEffectID;
		param.effectID [1] = DamageEffectID;
		param.effectID [2] = AttackEffectID;
		return param;
	}


    public void setEdit(bool t)
    {
        isEdit = t;
    }

    void OnLevelWasLoaded()
    {
        gameScene_set = false;
    }

    public void PrintParam()
    {
        string message = string.Empty;
        message += "Speed:" + _SPD.ToString() + ":";
        message += "Jump:" + _JMP.ToString() + ":";
        message += "Life:" + _LIFE.ToString() + ":";
        message += "Gravity:" + _GRV.ToString() + "\n";
        message += "BGM" + BGM + ":";
        message += "JumpSE" + JumpSE + ":";
        message += "StepSE" +  StepSE + ":";
        message += "DamageSE" + DamageSE + ":";
        message += "SpringSE" + SpringSE + ":";
        Debug.LogError(message);



    }
}