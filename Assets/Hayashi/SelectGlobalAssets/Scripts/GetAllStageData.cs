using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Networking;



public class GetAllStageData : MonoBehaviour {

    public static GetAllStageData instance;

    public static List<StageDataClass> Stage = new List<StageDataClass>();
    bool LoadisDone;


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
        Debug.Log(Stage.Count);
 
        Stage.Remove(Stage[Stage.Count - 1]);
    
        callback(Stage);


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
