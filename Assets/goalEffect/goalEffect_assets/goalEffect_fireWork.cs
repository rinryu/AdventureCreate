using UnityEngine;
using System.Collections;

public class goalEffect_fireWork : MonoBehaviour {
    GameObject[] fwOrigin = new GameObject[16];
	// Use this for initialization
	void Start () {
        int count = 0;
        foreach (Transform child in transform)
        {
            fwOrigin[count] = child.gameObject;
            count++;
        }


        StartCoroutine("CT_RandomRepeat");
        

    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    IEnumerator CT_RandomRepeat()
    {
        while (true)
        {
            for (int i = 0; i < fwOrigin.Length; i++)
            {
                fwOrigin[i].transform.localPosition = new Vector3(
                    0 + 500 * (Random.value - 0.5f) * 4f,
                    50 + 500 * (Random.value - 0.5f) * 2f,
                    0 + 0 * (Random.value - 0.5f)
                    );
            }
            yield return new WaitForSeconds(4.0f);
        }
    }
}
