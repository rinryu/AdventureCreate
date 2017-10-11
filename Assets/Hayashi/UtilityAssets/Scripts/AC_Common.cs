using System.Collections;
using System.Collections.Generic;
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

    public GameObject InstantiateObject(string in_path,string in_name,Transform in_parent)
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

    public IEnumerator LoadAssetBundle(string url,string type,string name, System.Action<GameObject> callback = null)
    {
        string path = url + "/" + type;
        WWW www = WWW.LoadFromCacheOrDownload(path, 1);
        yield return www;

        AssetBundle bundle = www.assetBundle;

        callback(bundle.LoadAsset(name) as GameObject);


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
}
