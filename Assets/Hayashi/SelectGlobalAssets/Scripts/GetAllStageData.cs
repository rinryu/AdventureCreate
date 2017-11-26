using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Networking;



public class GetAllStageData : MonoBehaviour {

	private static GetAllStageData mInstance;
	private GetAllStageData()
	{
		Debug.Log("Create Instance SaveStageData");
	}
	public static GetAllStageData Instance
	{
		get
		{
			if (mInstance == null)
			{
				GameObject obj = new GameObject("GetAllStageData");
				mInstance = obj.AddComponent<GetAllStageData>();
			}
			return mInstance;
		}

	}

	public int stageID;
    public List<StageDataClass> Stage = new List<StageDataClass>();
    bool LoadisDone;
	public StageDataClass GetSelectStageData {
		get {
			return Stage [stageID];
		}
	}
	public void Awake()
	{
		DontDestroyOnLoad(this);
	}


    public void GetAllStage(Action<List<StageDataClass>> callback = null)
    {
        StartCoroutine(GetAllStageCoroutine(callback));
    }

    IEnumerator GetAllStageCoroutine(Action<List<StageDataClass>> callback = null)
    {
        
        Debug.Log("DownLoad ALLSTAGE");
        WWWForm form = new WWWForm();
        Dictionary<string, string> headers = form.headers;
        headers["Authorization"] = "Basic " + System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("adventurecreate:actest"));
        WWW www = new WWW(ServerSetting.DEVURL + "GetAllStage.php", null, headers);
        while (!www.isDone)
        {
            yield return null;
        }
        yield return www;
        Debug.Log("Download ALLSTAGE end");
        Debug.Log(www.text);
        string[] str = www.text.Split(';');
        Debug.Log(str.Length);
        Debug.Log(str[str.Length - 2]);
        foreach (string s in str)
        {
            Stage.Add(JsonUtility.FromJson<StageDataClass>(s));
        }
 
        Stage.Remove(Stage[Stage.Count - 1]);

		foreach (StageDataClass s in Stage) {
			s.Initialize ();
		}

        callback(Stage);


    }

	public void SendCouneter(Action callback){
		StartCoroutine (SendCouneterCroutine (callback));
	}

	IEnumerator SendCouneterCroutine(Action callback){
		WWWForm form = new WWWForm();
		StageDataClass stage = GetSelectStageData;
		StageState counter = new StageState (stage.StageName, stage.playCount, stage.clearCount, stage.missCount);
		string json = JsonUtility.ToJson(counter);
		Debug.Log(json);
		form.AddField("Counter", json);
		Dictionary<string, string> headers = form.headers;
		headers["Authorization"] = "Basic " + System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("adventurecreate:actest"));

		byte[] data = form.data;

		#if DEVELOP
		WWW www = new WWW(ServerSetting.DEVURL + "SetCounter.php", data,headers);
		#else
		WWW www = new WWW(ServerSetting.MASTERURL + "SaveStage.php", data,headers);
		#endif
		yield return www;
		if (!string.IsNullOrEmpty(www.error))
		{
			Debug.LogError(www.error);
			yield break;

		}
		Debug.Log (www.text);
		callback ();
	}

    public void SetActive(List<StageDataClass> stage)
    {

    }


    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
