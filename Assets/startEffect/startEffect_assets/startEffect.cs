using UnityEngine;
using System.Collections;

public class startEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.parent = GameObject.Find("UI").transform;
        transform.position = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        transform.localScale = Vector2.one;
        StartCoroutine("Life");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Life()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(this.gameObject);
        yield return null;
    }
}
