using UnityEngine;
using System.Collections;

public class GameParameter : MonoBehaviour {

	private static GameParameter _instance;
	private GameParameter(){
		Debug.Log ("Create instance GameParameter");
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

    public bool isEdit = false;
    public bool isGlobal = false;


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

	private static bool _isMenu;
	public static bool isMenu{
		set{
			_isMenu = value;
		}
		get{
			return _isMenu;
		}
	}

    // Use this for initialization
    void Start() {
        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update() {

        if(Application.loadedLevelName == "selectScene")
        {
            isEdit = false;
            isGlobal = false;
        }else if (Application.loadedLevelName == "editorScene")
        {
            isEdit = true;
            isGlobal = false;
        }else if (Application.loadedLevelName == "selectGlobalScene")
        {
            isGlobal = true;
        }else if (Application.loadedLevelName == "gameScene" || Application.loadedLevelName == "gameGlobalScene")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Chara_Move cm = GameObject.Find("player(Clone)").GetComponent<Chara_Move>();
                if (cm.GetisClear() || cm.GetisGameOver()) return;
				isMenu = !isMenu;
            }
        }      
    }


    public void SetParam(ParameterData in_param)
    {
        Debug.Log("SetParam");

		spd = (Parameter)in_param.Speed;
		jmp = (Parameter)in_param.Jump;
		life = (Life)in_param.Life;
		grv = (Parameter)in_param.Gravity;
		BGM = Resources.Load<AudioClip>("Sound/BGM_" +in_param.BGMID.ToString());
		JumpSE = Resources.Load<AudioClip>("Sound/SE_" + in_param.JumpSE.ToString());
		StepSE = Resources.Load<AudioClip>("Sound/SE_" + in_param.StepSE.ToString());
		SpringSE = Resources.Load<AudioClip>("Sound/SE_" + in_param.SpringSE.ToString());
		DamageSE = Resources.Load<AudioClip>("Sound/SE_" + in_param.DamageSE.ToString());
		goalEffectID = in_param.GoalEffect;
		DamageEffectID = in_param.DamageEffect;
		AttackEffectID = in_param.AttackEffect;


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