using UnityEngine;
using System.Collections;

public class goalEffect_originLine : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.parent = GameObject.Find("Main Camera").transform;
        transform.localPosition = new Vector3(0, 0, 60);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
