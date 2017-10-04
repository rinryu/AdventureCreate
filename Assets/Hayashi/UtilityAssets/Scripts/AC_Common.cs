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
