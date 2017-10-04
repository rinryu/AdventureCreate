using UnityEngine;
using System.Collections;

public class editor_effectManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.localScale = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Open()
    {
        transform.localScale = Vector3.one;
    }
    public void Close()
    {
        transform.localScale = Vector3.zero;
    }
}
