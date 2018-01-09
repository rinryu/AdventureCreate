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
			return Stage [stageID-1];
		}
	}
	public void Awake()
	{
		DontDestroyOnLoad(this);
	}


    public void GetAllStage(Action<List<StageDataClass>> callback = null)
    {

        if (Stage.Count == 0)
        {
            StartCoroutine(GetAllStageCoroutine(80));
            StartCoroutine(GetAllStageCoroutine(104,callback));

        }
        else callback(Stage);
    }

    IEnumerator GetAllStageCoroutine(int getNumber,Action<List<StageDataClass>> callback = null)
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
        Debug.Log("Download ALLSTAGE end");
        Debug.Log(www.text);
        Stage.Add(JsonUtility.FromJson<StageDataClass>(www.text));
 
		foreach (StageDataClass s in Stage) {
			s.Initialize ();
		}
        if (callback != null)
        {
            callback(Stage);
        }


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

    public void SendDeathPoint(Vector2 in_pos)
    {
        StartCoroutine(SendDeathPointCoroutine(in_pos));
    }



    IEnumerator SendDeathPointCoroutine(Vector2 in_pos)
    {
        WWWForm form = new WWWForm();
        int x, y;
        x = (int)(Math.Round(in_pos.x / GenerateGlobal_map.TileSize));
        if (x < 0) x = 0;
        else if (x > 50) x = 50;
        y = (int)(Math.Round(in_pos.y / GenerateGlobal_map.TileSize));
        if (y < 0) y = 0;
        DeathPoint deathPoint = new DeathPoint(GetSelectStageData.StageNumber, x, y);
        string json = JsonUtility.ToJson(deathPoint);
        Debug.Log(json);
        form.AddField("DeathPoint", json);
        Dictionary<string, string> headers = form.headers;
        headers["Authorization"] = "Basic " + System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("adventurecreate:actest"));
        byte[] data = form.data;
#if DEVELOP
        WWW www = new WWW(ServerSetting.DEVURL + "AddDeathPoint.php", data, headers);
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
