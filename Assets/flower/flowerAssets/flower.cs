using UnityEngine;
using System.Collections;

public class flower : MonoBehaviour {
    GameObject model;
	// Use this for initialization
	void Start () {
        model = transform.FindChild("model_flower").gameObject;
        model.transform.rotation = Quaternion.EulerAngles(0, Mathf.PI * 0.5f * Random.RandomRange(0,8), 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
