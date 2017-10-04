using UnityEngine;
using System.Collections;

public class player_eyeManager : MonoBehaviour {
    public Texture eye_nomal, eye_close;
    Renderer renderer;
    bool newTurn;
	// Use this for initialization
	void Start () {
        newTurn = true;
        renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (newTurn)
        {
            StartCoroutine("eyeCondition");
            newTurn = false;
        }
	}

    IEnumerator eyeCondition()
    {
        int rand = 0;
        if (rand == 0)
        {
            Normal();
            yield return new WaitForSeconds(2.0f);
            Close();
            yield return new WaitForSeconds(0.2f);
            Normal();
            yield return new WaitForSeconds(0.2f);
            Close();
            yield return new WaitForSeconds(0.2f);
            Normal();
            yield return new WaitForSeconds(0.2f);
            Normal();
            yield return new WaitForSeconds(1.0f);
            Normal();
            yield return new WaitForSeconds(1.5f);
            Close();
            yield return new WaitForSeconds(0.2f);
            Normal();
            yield return new WaitForSeconds(1.6f);
            Close();
            yield return new WaitForSeconds(0.6f);
            Normal();
            yield return new WaitForSeconds(0.2f);
            Normal();
            yield return new WaitForSeconds(1.0f);
            Close();
            yield return new WaitForSeconds(0.6f);
            Normal();
            yield return new WaitForSeconds(0.2f);
            Normal();
            yield return new WaitForSeconds(1.0f);
            newTurn = true;
        }
        yield return null;
    }

    void Normal()
    {
        renderer.material.mainTexture = eye_nomal;
    }
    void Close()
    {
        renderer.material.mainTexture = eye_close;
    }
}
