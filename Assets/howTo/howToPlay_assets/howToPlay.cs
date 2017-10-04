using UnityEngine;
using System.Collections;

public class howToPlay : MonoBehaviour {
    Vector2 firstPos;
    bool isOpen;
    float step;
    float t;

    Chara_Move chara_move;
    bool firstContact = true;

    // Use this for initialization
    void Start () {
        t = 0.0f;
        step = Screen.height * 1.0f * Time.deltaTime;
        isOpen = false;
        firstPos = transform.position;
        firstContact = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (firstContact)
        {
            chara_move = GameObject.Find("player(Clone)").GetComponent<Chara_Move>();
            firstContact = false;
        }
	    if (!Input.anyKey)
        {
            t -= 1.0f * Time.deltaTime;
        }
        if (Input.anyKey)
        {
            t = 2.0f;
        }
        if (chara_move.isClear)
        {
            t = 2.0f;
        }

        if (t < 0.0f)
        {
            isOpen = true;
        }
        else
        {
            isOpen = false;
        }

        if (isOpen)
        {
            transform.position = Vector3.MoveTowards(transform.position, firstPos, step);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, firstPos + Vector2.down * Screen.height * 0.4f, step);
        }
    }
}
