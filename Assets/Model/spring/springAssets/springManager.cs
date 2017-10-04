using UnityEngine;
using System.Collections;

public class springManager : MonoBehaviour {
    Animator aniCon;
	// Use this for initialization
	void Start () {
        aniCon = transform.FindChild("model_spring").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        /*
	    if (Input.GetKeyDown(KeyCode.A))
        {
            PlayBoyon();
        }
        */
	}

    public void PlayBoyon()
    {
        //aniCon.Stop();
        aniCon.Play("spring_boyon");
    }
}
