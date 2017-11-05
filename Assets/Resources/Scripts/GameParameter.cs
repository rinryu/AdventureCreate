using UnityEngine;
using System.Collections;

public class GameParameter : MonoBehaviour {

    public static bool isEdit = false;
    public static bool isGlobal = false;

    enum Speed
    {
        Min,
        ThreeQuarter,
        Normal,
        FiveQuarter,
        Max
    }
    [SerializeField]
    Speed spd;
    public static float _SPD;

    enum Jump
    {
        Min,
        ThreeQuarter,
        Normal,
        FiveQuarter,
        Max
    }
    [SerializeField]
    Jump jmp;
    public static float _JMP;

    enum Gravity
    {
        Min,
        ThreeQuarter,
        Normal,
        FiveQuarter,
        Max
    }
    [SerializeField]
    Gravity grv;
    public static float _GRV;

    enum Life
    {
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight
    }
    [SerializeField]
    Life life;
    public static int _LIFE;

    [SerializeField]
    public static AudioClip BGM;
    [SerializeField]
    public static AudioClip JumpSE;
    [SerializeField]
    public static AudioClip StepSE;
    [SerializeField]
    public static AudioClip SpringSE;
    [SerializeField]
    public static AudioClip DamageSE;
    [SerializeField]
    public static AudioClip aSE;
    [SerializeField]
    public static AudioClip bSE;

    public static int goalEffectID;

    public static int DamageEffectID;

    public static int AttackEffectID;

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
        }
        if (Application.loadedLevelName == "editorScene")
        {
            GameParameter.isEdit = true;
            GameParameter.isGlobal = false;
        }
        if (Application.loadedLevelName == "selectGlobalScene")
        {
            GameParameter.isGlobal = true;
        }

        if (Application.loadedLevelName != "gameScene" || Application.loadedLevelName != "gameGlobalScene")
        {
            SetSpeed();
            SetJump();
            SetGravity();
            SetLife();
            SetSound();

        }
        else if (Application.loadedLevelName == "gameScene" || Application.loadedLevelName == "gameGlobalScene")
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

    void SetSpeed()
    {
        //Speed
        switch (editor_editManager.value[0, editor_editManager.stageID])
        {
            case -2:
                spd = Speed.Min;
                _SPD = 0.5f;
                break;
            case -1:
                spd = Speed.ThreeQuarter;
                _SPD = 0.75f;
                break;
            case 0:
                spd = Speed.Normal;
                _SPD = 1f;
                break;
            case 1:
                spd = Speed.FiveQuarter;
                _SPD = 1.25f;
                break;
            case 2:
                spd = Speed.Max;
                _SPD = 1.5f;
                break;
        }
    }

    void SetJump()
    {
        //Jump
        switch (editor_editManager.value[1, editor_editManager.stageID])
        {
            case -2:
                jmp = Jump.Min;
                _JMP = 0.5f;
                break;
            case -1:
                jmp = Jump.ThreeQuarter;
                _JMP = 0.75f;
                break;
            case 0:
                jmp = Jump.Normal;
                _JMP = 1f;
                break;
            case 1:
                jmp = Jump.FiveQuarter;
                _JMP = 1.25f;
                break;
            case 2:
                jmp = Jump.Max;
                _JMP = 1.5f;
                break;
        }
    }

    void SetGravity()
    {
        //Gravity
        switch (editor_editManager.value[3, editor_editManager.stageID])
        {
            case -2:
                grv = Gravity.Min;
                _GRV = 0.5f;
                break;
            case -1:
                grv = Gravity.ThreeQuarter;
                _GRV = 0.25f;
                break;
            case 0:
                grv = Gravity.Normal;
                _GRV = 1f;
                break;
            case 1:
                grv = Gravity.FiveQuarter;
                _GRV = 1.25f;
                break;
            case 2:
                grv = Gravity.Max;
                _GRV = 1.5f;
                break;
        }
    }

    void SetLife()
    {
        switch (editor_editManager.value[2, editor_editManager.stageID])
        {
            case 1:
                life = Life.One;
                _LIFE = 1;
                break;
            case 2:
                life = Life.Two;
                _LIFE = 2;
                break;
            case 3:
                life = Life.Three;
                _LIFE = 3;
                break;
            case 4:
                life = Life.Four;
                _LIFE = 4;
                break;
            case 5:
                life = Life.Five;
                _LIFE = 5;
                break;
            case 6:
                life = Life.Six;
                _LIFE = 6;
                break;
            case 7:
                life = Life.Seven;
                _LIFE = 7;
                break;
            case 8:
                life = Life.Eight;
                _LIFE = 8;
                break;

            default:
                life = Life.One;
                _LIFE = 1;
                break;
        }
    }

    void SetSound()
    {
        //Debug.Log(editor_editManager.stageID);
        BGM = Resources.Load<AudioClip>("Sound/BGM_" + editor_editManager.BGM_ID[0,editor_editManager.stageID].ToString());
        JumpSE = Resources.Load<AudioClip>("Sound/SE_"+ editor_editManager.SE_ID[0, editor_editManager.stageID].ToString());
        StepSE = Resources.Load<AudioClip>("Sound/SE_" + editor_editManager.SE_ID[1, editor_editManager.stageID].ToString());
        SpringSE = Resources.Load<AudioClip>("Sound/SE_" + editor_editManager.SE_ID[2, editor_editManager.stageID].ToString());
        DamageSE = Resources.Load<AudioClip>("Sound/SE_" + editor_editManager.SE_ID[3, editor_editManager.stageID].ToString());
        aSE = Resources.Load<AudioClip>("Sound/SE_" + editor_editManager.SE_ID[4,editor_editManager.stageID].ToString());
        bSE = Resources.Load<AudioClip>("Sound/SE_" + editor_editManager.SE_ID[5, editor_editManager.stageID].ToString());
    }

    void SetSpeed(int in_speed)
    {
        //Speed
        switch (in_speed)
        {
            case -2:
                spd = Speed.Min;
                _SPD = 0.5f;
                break;
            case -1:
                spd = Speed.ThreeQuarter;
                _SPD = 0.75f;
                break;
            case 0:
                spd = Speed.Normal;
                _SPD = 1f;
                break;
            case 1:
                spd = Speed.FiveQuarter;
                _SPD = 1.25f;
                break;
            case 2:
                spd = Speed.Max;
                _SPD = 1.5f;
                break;
        }
    }

    void SetJump(int in_jump)
    {
        //Jump
        switch (in_jump)
        {
            case -2:
                jmp = Jump.Min;
                _JMP = 0.5f;
                break;
            case -1:
                jmp = Jump.ThreeQuarter;
                _JMP = 0.75f;
                break;
            case 0:
                jmp = Jump.Normal;
                _JMP = 1f;
                break;
            case 1:
                jmp = Jump.FiveQuarter;
                _JMP = 1.25f;
                break;
            case 2:
                jmp = Jump.Max;
                _JMP = 1.5f;
                break;
        }
    }

    void SetGravity(int in_gravity)
    {
        //Gravity
        switch (in_gravity)
        {
            case -2:
                grv = Gravity.Min;
                _GRV = 0.5f;
                break;
            case -1:
                grv = Gravity.ThreeQuarter;
                _GRV = 0.25f;
                break;
            case 0:
                grv = Gravity.Normal;
                _GRV = 1f;
                break;
            case 1:
                grv = Gravity.FiveQuarter;
                _GRV = 1.25f;
                break;
            case 2:
                grv = Gravity.Max;
                _GRV = 1.5f;
                break;
        }
    }

    void SetLife(int in_life)
    {
        switch (in_life)
        {
            case 1:
                life = Life.One;
                _LIFE = 1;
                break;
            case 2:
                life = Life.Two;
                _LIFE = 2;
                break;
            case 3:
                life = Life.Three;
                _LIFE = 3;
                break;
            case 4:
                life = Life.Four;
                _LIFE = 4;
                break;
            case 5:
                life = Life.Five;
                _LIFE = 5;
                break;
            case 6:
                life = Life.Six;
                _LIFE = 6;
                break;
            case 7:
                life = Life.Seven;
                _LIFE = 7;
                break;
            case 8:
                life = Life.Eight;
                _LIFE = 8;
                break;

            default:
                life = Life.One;
                _LIFE = 1;
                break;
        }
    }

    void SetSound(int in_BGM,int[] in_SE)
    {
        //Debug.Log(editor_editManager.stageID);
        //Debug.Log(editor_editManager.BGM_ID[0,editor_editManager.stageID]);

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
        SetSpeed(in_param.value[0]);
        SetJump(in_param.value[1]);
        SetLife(in_param.value[2]);
        SetGravity(in_param.value[3]);
        SetSound(in_param.BGMID, in_param.SEID);
        SetEffect(in_param.effectID);
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