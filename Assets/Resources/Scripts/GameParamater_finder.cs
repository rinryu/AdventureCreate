using UnityEngine;
using System.Collections;

public class GameParamater_finder : MonoBehaviour {
    public GameObject Gameparamater; 
	// Use this for initialization
	void Start () {
        if (!GameObject.Find("GameParamater"))
        {
            GameObject instantiate = Instantiate(Gameparamater);
            instantiate.name = "GameParamater";
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
