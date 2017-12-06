using UnityEngine;
using System.Collections;

public class missEffect : MonoBehaviour {
    GameObject missSprite;
    public string backSceneName;
	// Use this for initialization
	void Start () {
        missSprite = transform.FindChild("sprite").gameObject;
        transform.parent = GameObject.Find("UI").transform;
        transform.localScale = Vector3.one;
        transform.localScale = Vector3.one;
        transform.position = new Vector2(Screen.width * 0.5f, Screen.height * 0.75f);
        StartCoroutine("missIE");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator missIE()
    {
		//if (GameParameter.instance.isGlobal) GameParameter.instance.isGlobal = false;
        yield return new WaitForSeconds(2.5f);
        GameObject.Find("sceneChangeManager").GetComponent<sceneChangeManager>().ChangeScene(backSceneName);
    }
}
