using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System; //Exception
public class SaveStageData : MonoBehaviour {

    string Readdata;
    bool Load = false;
    [SerializeField]
    Text stagename;
    [SerializeField]
    sceneChangeManager sceneschange;
    [SerializeField]
    List<StageDataClass> Stage = new List<StageDataClass>();

    bool LoadisDone = false;

    private void Awake()
    {
        StartCoroutine(GetStage());
        if(stagename != null) stagename.text = editor_editManager.Stagename;

    }

    void Start()
    {
        if (stagename == null) Load = false;
        else Load = true;
    }

    void Update()
    {
        if (LoadisDone)
        {
            if (!Load)
            {

                AutoLoad();
                Load = true;
                Debug.Log("Load");
            }
        }
    }

    public void textLoad(int stage)
    {
        Readdata = Stage[stage].StageData;
    }

    public void ParameterLoad()
    {
        Debug.Log("parameterLoad");
        for (int p = 0; p < Stage.Count; p++) //p=stageの数
        {
            List<string> para = new List<string>();
            para.AddRange(Stage[p].Parameter.Split('\n'));
            para.RemoveAll(s => s == "");

            int count = 0;


            for (int i = 0; i < editor_editManager.value.GetLength(0); i++)
            {
                Debug.Log(Int32.Parse(para[count]));
                editor_editManager.value[i, p] = Int32.Parse(para[count]);
                count++;
            }

            editor_editManager.BGM_ID[0, p] = Int32.Parse(para[count]);
            count++;

            for (int i = 0; i < editor_editManager.SE_ID.GetLength(0); i++)
            {
                editor_editManager.SE_ID[i, p] = Int32.Parse(para[count]);
                count++;
            }

            editor_editManager.effectID[0, p] = Int32.Parse(para[count]);
            count++;

            editor_editManager.effectID[1, p] = Int32.Parse(para[count]);
            count++;

            editor_editManager.effectID[2, p] = Int32.Parse(para[count]);
            count++;

        }
    }

    void Read(int stage)
    {
        int Count = 0;
        Readdata = "";
        textLoad(stage);
        for (int x = 0; x < editor_editManager.editMapData.GetLongLength(0); x++)
        {
            for (int y = 0; y < editor_editManager.editMapData.GetLongLength(1); y++)
            {
                if (Int32.Parse(Readdata[Count].ToString()) < 10)
                {
                    editor_editManager.editMapData[x, y, stage] = Int32.Parse(Readdata[Count].ToString());
                }
                else
                {
                    if (Readdata[Count].ToString() == "a") editor_editManager.editMapData[x, y, stage] = 10;
                    if (Readdata[Count].ToString() == "b") editor_editManager.editMapData[x, y, stage] = 11;
                    if (Readdata[Count].ToString() == "c") editor_editManager.editMapData[x, y, stage] = 12;
                    if (Readdata[Count].ToString() == "d") editor_editManager.editMapData[x, y, stage] = 13;
                    if (Readdata[Count].ToString() == "e") editor_editManager.editMapData[x, y, stage] = 14;
                    if (Readdata[Count].ToString() == "f") editor_editManager.editMapData[x, y, stage] = 15;
                    if (Readdata[Count].ToString() == "g") editor_editManager.editMapData[x, y, stage] = 16;
                    if (Readdata[Count].ToString() == "h") editor_editManager.editMapData[x, y, stage] = 17;
                    if (Readdata[Count].ToString() == "i") editor_editManager.editMapData[x, y, stage] = 18;
                    if (Readdata[Count].ToString() == "j") editor_editManager.editMapData[x, y, stage] = 19;
                    if (Readdata[Count].ToString() == "k") editor_editManager.editMapData[x, y, stage] = 20;
                    if (Readdata[Count].ToString() == "l") editor_editManager.editMapData[x, y, stage] = 21;
                    if (Readdata[Count].ToString() == "m") editor_editManager.editMapData[x, y, stage] = 22;
                    if (Readdata[Count].ToString() == "n") editor_editManager.editMapData[x, y, stage] = 23;
                    if (Readdata[Count].ToString() == "o") editor_editManager.editMapData[x, y, stage] = 24;
                    if (Readdata[Count].ToString() == "p") editor_editManager.editMapData[x, y, stage] = 25;
                    if (Readdata[Count].ToString() == "q") editor_editManager.editMapData[x, y, stage] = 26;
                    if (Readdata[Count].ToString() == "r") editor_editManager.editMapData[x, y, stage] = 27;
                    if (Readdata[Count].ToString() == "s") editor_editManager.editMapData[x, y, stage] = 28;
                    if (Readdata[Count].ToString() == "t") editor_editManager.editMapData[x, y, stage] = 29;
                    if (Readdata[Count].ToString() == "u") editor_editManager.editMapData[x, y, stage] = 30;
                    if (Readdata[Count].ToString() == "v") editor_editManager.editMapData[x, y, stage] = 31;
                    if (Readdata[Count].ToString() == "w") editor_editManager.editMapData[x, y, stage] = 32;
                    if (Readdata[Count].ToString() == "x") editor_editManager.editMapData[x, y, stage] = 33;
                    if (Readdata[Count].ToString() == "y") editor_editManager.editMapData[x, y, stage] = 34;
                    if (Readdata[Count].ToString() == "z") editor_editManager.editMapData[x, y, stage] = 35;
                }
                Count++;
            }
        }
    }

    public void AutoLoad()
    {
        //オートロード
        for (int i = 0; i < Stage.Count; i++)
        {
            Read(i);
        }
        ParameterLoad();
    }

    public string ParameterSave()
    {
        string str = string.Empty;


        for (int i = 0; i < editor_editManager.value.GetLength(0); i++)
        {
            str += editor_editManager.value[i,1].ToString() + "\n";
        }

        //for (int i = 0; i < editor_editManager.BGM_ID.GetLength(1); i++)
        //{
        str += editor_editManager.BGM_ID[0, 1].ToString() + "\n";
        //}

        for (int i = 0; i < editor_editManager.SE_ID.GetLength(0); i++)
        {
            str += editor_editManager.SE_ID[i, 1].ToString() + "\n";
        }

        str += editor_editManager.effectID[0, 1].ToString() + "\n";//goaleffect

        str += editor_editManager.effectID[1, 1].ToString() + "\n";//damageeffect

        str += editor_editManager.effectID[2, 1].ToString() + "\n";//damageeffect

        return str;
    }


    private string SplitString(string str, char ch)
    {
        string[] SplitAfter = str.Split(ch);
        string result = string.Empty;
        foreach (string s in SplitAfter) result += s;
        return result;
    }

    public void Save(string nextStage)
    {
        StartCoroutine(SaveData(nextStage));

    }

    IEnumerator SaveData(string next)
    {
        Debug.Log(editor_editManager.stageID);
        WWWForm form = new WWWForm();
        StageDataClass stage = new StageDataClass();
        stage.user_ID = UserData.Instanse.ID;
        stage.StageName = UserData.Instanse.username +"-"+ editor_editManager.Stagename;
        stage.StageData = WriteStageData(editor_editManager.stageID);
        stage.Parameter = ParameterSave();       
        stage.CreateDate = DateTime.Now.ToString();
        string json = JsonUtility.ToJson(stage);
        Debug.Log(json);
        form.AddField("Stage", json);
        Dictionary<string, string> headers = form.headers;
        headers["Authorization"] = "Basic " + System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("adventurecreate:actest"));

        byte[] data = form.data;

#if DEVELOP
        WWW www = new WWW(ServerSetting.DEVURL + "SaveStage.php", data,headers);
#else
        WWW www = new WWW(ServerSetting.MASTER + "SaveStage.php", data,headers);
#endif
        yield return www;
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.LogError(www.error);
            yield break;

        }
        Debug.Log(www.text);
        sceneschange.ChangeScene(next);
    }

    string WriteStageData(int stage)
    {
        string Writedata = "";

        for (int x = 0; x < 50; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                if ((Int32)editor_editManager.editMapData[x, y, stage] < 10)//
                {//
                    Writedata += (Int32)editor_editManager.editMapData[x, y, stage];
                }//
                else//
                {//
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 10) Writedata += "a";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 11) Writedata += "b";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 12) Writedata += "c";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 13) Writedata += "d";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 14) Writedata += "e";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 15) Writedata += "f";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 16) Writedata += "g";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 17) Writedata += "h";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 18) Writedata += "i";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 19) Writedata += "j";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 20) Writedata += "k";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 21) Writedata += "l";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 22) Writedata += "m";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 23) Writedata += "n";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 24) Writedata += "o";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 25) Writedata += "p";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 26) Writedata += "q";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 27) Writedata += "r";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 28) Writedata += "s";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 29) Writedata += "t";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 30) Writedata += "u";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 31) Writedata += "v";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 32) Writedata += "w";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 33) Writedata += "x";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 34) Writedata += "y";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 35) Writedata += "z";
                }//
            }
        }
        return Writedata;
    }

    IEnumerator GetStage()
    {
        Debug.Log("downloadbegin");
        WWWForm form = new WWWForm();
        form.AddField("userID", UserData.Instanse.ID);
        Dictionary<string, string> headers = form.headers;
        byte[] data = form.data;
        headers["Authorization"] = "Basic " + System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("adventurecreate:actest"));
#if DEVELOP
        WWW www = new WWW(ServerSetting.DEVURL + "GetStage.php", data,headers);
#else
        WWW www = new WWW(ServerSetting.MATERURL + "GetStage.php", form);
#endif
        while (!www.isDone)
        {
            yield return null;
        }
        yield return www;
        string[] result = www.text.Split(';');
        foreach (string str in result)
        {
#if DEBUG_MODE
            Debug.Log(str);
#endif
            Stage.Add(JsonUtility.FromJson<StageDataClass>(str));

        }
        Stage.Remove(Stage[Stage.Count - 1]);
#if DEBUG_MODE
        foreach(StageDataClass s in Stage)
        {
            Debug.Log(s.StageName);
        }
#endif
        Debug.Log("downloadEnd");
        LoadisDone = true;

    }

}
