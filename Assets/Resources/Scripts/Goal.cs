using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
    GameObject player;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        player = GameObject.Find("player(Clone)");
        if(Vector3.Distance(gameObject.transform.position,player.transform.position) < 45)
        {
            Debug.Log("Clear");
        }
    }
}
