using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewBehaviourScript : MonoBehaviour {
    public GameObject text;
	// Use this for initialization
	void Start () {
        text.GetComponent<InputField>().text = Application.streamingAssetsPath;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
