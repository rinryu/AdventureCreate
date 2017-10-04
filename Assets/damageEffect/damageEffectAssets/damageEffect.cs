using UnityEngine;
using System.Collections;

public class damageEffect : MonoBehaviour {
    public float life;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        life -= 1.0f * Time.deltaTime;
        if (life < 0.0f)
        {
            Destroy(this.gameObject);
        }
	}
}
