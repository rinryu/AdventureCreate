using UnityEngine;
using System.Collections;

public class goalUI : MonoBehaviour {
    GameObject uiAssets;
	// Use this for initialization
	void Start () {
        uiAssets = transform.FindChild("goalEffect_stageClear").gameObject;
        uiAssets.transform.parent = GameObject.Find("UI").transform;
        uiAssets.transform.localScale = Vector3.one;
        uiAssets.transform.position = new Vector2(
            Screen.width * 0.5f,
            Screen.height * 0.8f
            );
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
