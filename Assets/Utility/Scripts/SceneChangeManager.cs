using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChangeManager : MonoBehaviour {

    public System.Action CallBackSceneChange = () => { };
	public static SceneChangeManager _Instance;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChengeScene(string name)
    {
        CallBackSceneChange();
        SceneManager.LoadSceneAsync(name);
    }

}
