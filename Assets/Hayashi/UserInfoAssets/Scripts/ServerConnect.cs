using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ServerConnect : MonoBehaviour {

    string URL = "http://localhost:8080/WebGL/Database/user_out.php";

    [SerializeField]
    Text username;
    // Use this for initialization
    void Start () {
        Debug.Log(UtilityBox.username);

        username.text = UtilityBox.username;
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
