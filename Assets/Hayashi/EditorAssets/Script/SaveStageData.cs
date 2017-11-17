using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System; //Exception

public class SaveStageData : MonoBehaviour {

    private static SaveStageData mInstance;
    private SaveStageData()
    {
        Debug.Log("Create Instance");
    }
    public static SaveStageData Instance
    {
        get
        {
            if (mInstance == null)
            {
                GameObject obj = new GameObject("SaveStageData");
                mInstance = obj.AddComponent<SaveStageData>();
            }
            return mInstance;
        }

    }

	public StageDataClass GetSelectStageData {
		get {
			return Stage [stageID];
		}
	}


    string Readdata;
    bool Load = false;
    [SerializeField]
    Text stagename;
    [SerializeField]
    sceneChangeManager sceneschange;
    [SerializeField]
    public List<StageDataClass> Stage = new List<StageDataClass>();
    public int stageID;
    bool LoadisDone = false;

    public void GetStageCoroutine()
    {
        StartCoroutine(GetStage());
        if (stagename != null) stagename.text = editor_editManager.Stagename;
    }

    public void Awake()
    {
        DontDestroyOnLoad(this);
    }

    //void Start()
    //{
    //    if (stagename == null) Load = false;
    //    else Load = true;
    //}

    //void Update()
    //{
    //    if (LoadisDone)
    //    {
    //        if (!Load)
    //        {

    //            AutoLoad();
    //            Load = true;
    //            Debug.Log("Load");
    //        }
    //    }
    //}

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


    private string SplitString(string str, char ch)
    {
        string[] SplitAfter = str.Split(ch);
        string result = string.Empty;
        foreach (string s in SplitAfter) result += s;
        return result;
    }

    public void Save()
    {
        Debug.Log("Save Start");
        StartCoroutine(SaveData());
    }

    IEnumerator SaveData()
    {
        Debug.Log(editor_editManager.stageID);
        WWWForm form = new WWWForm();
        string json = JsonUtility.ToJson(GetSelectStageData);
        Debug.Log(json);
        form.AddField("Stage", json);
        Dictionary<string, string> headers = form.headers;
        headers["Authorization"] = "Basic " + System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("adventurecreate:actest"));

        byte[] data = form.data;

#if DEVELOP
        WWW www = new WWW(ServerSetting.DEVURL + "SaveStage.php", data,headers);
#else
        WWW www = new WWW(ServerSetting.MASTERURL + "SaveStage.php", data,headers);
#endif
        yield return www;
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.LogError(www.error);
            yield break;

        }
        Debug.Log(www.text);
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
        WWW www = new WWW(ServerSetting.MASTERURL + "GetStage.php", form);
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
        //AutoLoad();
    }


}
