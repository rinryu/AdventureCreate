using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AC_Common : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject InstanciateObject(GameObject in_obj,Transform in_parent)
    {
        GameObject obj = Instantiate(in_obj);
        obj.transform.SetParent(in_parent);
        return obj;
    }

    public GameObject InstanciateObject(string in_path,string in_name,Transform in_parent)
    {
        string path = in_path + "/" + in_name;
        GameObject obj = Resources.Load(path) as GameObject;
        obj.transform.SetParent(in_parent);
        return obj;
    }

    public AudioClip GetBGM(string in_path,string in_name)
    {
        string path = in_path + "/" + in_name;
        AudioClip bgm = Resources.Load(path) as AudioClip;
        return bgm;
    }

    public IEnumerator LoadAssetBundle(string url,Action<AssetBundle> callback)
    {
        //        WWW www = WWW.LoadFromCacheOrDownload(url, 1);
        WWW www = new WWW(url);
        yield return www;

        if (www.error != null)
        {
            Debug.LogError(www.error);
        }
        else
        {
            callback(www.assetBundle);
        }

    }

    public IEnumerator DelayforFrame(int frame, System.Action callback)
    {
        for(int i = 0; i < frame; i++)
        {
            yield return null;
        }

        callback();
    }

    public IEnumerator DelayforSecond(float second,System.Action callback)
    {
        yield return new WaitForSeconds(second);
        callback();
    }

	public void TakeScreenShot(int magnification,float delaySeconds){
		StartCoroutine(CoroutineTakeScreenShot(magnification,delaySeconds));
	}

	private IEnumerator CoroutineTakeScreenShot(int magnification,float delaySeconds){
		yield return new WaitForSeconds (delaySeconds);
		Application.CaptureScreenshot(Application.dataPath + "/Utility/ScreenShot/" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png", magnification);
	}



}
