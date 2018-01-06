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
        Debug.Log("Create Instance SaveStageData");
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
	[SerializeField]
	public StageDataClass GetSelectStageData {
		get {
			return Stage [stageID];
		}
	}

	public void SetSelectData(StageDataClass in_stage){
		Stage [stageID].StageData = in_stage.StageData;
	}
    public void SetSelectData(StageDataClass in_stage,int number)
    {
        Stage[number].StageData = in_stage.StageData;
    }

    string Readdata;
    bool Load = false;
    [SerializeField]
    Text stagename;
    [SerializeField]
    sceneChangeManager sceneschange;
    [SerializeField]
    public List<StageDataClass> Stage = new List<StageDataClass>();
    public List<DeathPoint> deathPoints = new List<DeathPoint>();
    public int stageID;
    bool LoadisDone = false;

    public GameParameter gameparameter;

	public void GetAllStageCoroutine()
	{
        StartCoroutine(GetAllStage());
    }

    public void Awake()
    {
        DontDestroyOnLoad(this);
    }


    public void Save()
    {
        Debug.Log("Save Start");
		StartCoroutine(SaveData());
    }

	IEnumerator SaveData()
    {
//        Debug.Log(editor_editManager.stageID);
        WWWForm form = new WWWForm();
		StageDataClass stage = GetSelectStageData;
//		ParameterData param = gameparameter.SaveParam ();
//		stage.Parameter = param;
		stage.UpdateDate = DateTime.Now.ToString();
        string json = JsonUtility.ToJson(stage);
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

	IEnumerator GetAllStage()
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
		if (www.error != null) {
			Debug.LogError (www.error);
		}
		Debug.Log (www.text);
		if (www.text != string.Empty) {
			string[] result = www.text.Split (';');
			foreach (string str in result) {
				Stage.Add (JsonUtility.FromJson<StageDataClass> (str));
			}
			Stage.Remove (Stage [Stage.Count - 1]);

		}
        Debug.Log("downloadEnd");

		foreach (StageDataClass s in Stage) {
			s.Initialize ();
		}
			
        //AutoLoad();
    }

    public void OverrideStageCoroutine(int setNumber,int getNumber,Action callback)
    {
        StartCoroutine(OverrideStage(setNumber,getNumber,callback));
    }

    IEnumerator OverrideStage(int setNumber,int getNumber,Action callback)
    {
        Debug.Log("GetReferenceStageBegin");
        WWWForm form = new WWWForm();
        form.AddField("stageNumber", getNumber);
        Dictionary<string, string> headers = form.headers;
        headers["Authorization"] = "Basic " + System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("adventurecreate:actest"));
        byte[] data = form.data;
        WWW www = new WWW(ServerSetting.DEVURL + "GetReferenceStageData.php", data, headers);
        while (!www.isDone)
        {
            yield return null;
        }
        yield return www;
        Debug.Log("DownLoad GetReferenceStage end");
        Debug.Log(www.text);
        if(www.error != null)
        {
            Debug.LogError(www.error);
        }
        SetSelectData(JsonUtility.FromJson<StageDataClass>(www.text),setNumber);
        callback();

    }

    public void GetDeathPoint(Action<List<DeathPoint>> callback)
    {
        StartCoroutine(GetDeathPointCorountine(callback, GetSelectStageData.StageNumber));
    }

    public void GetDeathPoint(Action<List<DeathPoint>> callback,int num)
    {
        if(num == 0) StartCoroutine(GetDeathPointCorountine(callback, GetSelectStageData.StageNumber));
        else StartCoroutine(GetDeathPointCorountine(callback, num));
    }


    IEnumerator GetDeathPointCorountine(Action<List<DeathPoint>> callback,int num)
    {
		deathPoints.Clear ();
		Debug.Log(string.Format("Downloading Get{0}Stage DeathPoint",num));
        WWWForm form = new WWWForm();
        form.AddField("stageNumber",num);
        Dictionary<string, string> headers = form.headers;
        headers["Authorization"] = "Basic " + System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("adventurecreate:actest"));
        byte[] data = form.data;
        WWW www = new WWW(ServerSetting.DEVURL + "GetDeathPoint.php", data, headers);
        while (!www.isDone)
        {
            yield return null;
        }
        yield return www;
        Debug.Log("Download AllDeathPoint end");
        Debug.Log(www.text);
        if (www.text == "None")
        {
            callback(null);
        }
        else
        {
            string[] str = www.text.Split(';');
            foreach (string s in str)
            {
                deathPoints.Add(JsonUtility.FromJson<DeathPoint>(s));
            }

            deathPoints.Remove(deathPoints[deathPoints.Count - 1]);

            callback(deathPoints);
        }
    }



}
