using UnityEngine;
using System.Collections;

public class enemy_attachment : MonoBehaviour {

    enemy _ene;
	// Use this for initialization
	void Start () {
        _ene = transform.parent.GetComponent<enemy>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col) {
        //Debug.Log("!!!!");

            if (col.gameObject.tag == "Object" || col.gameObject.tag == "Goal" || col.gameObject.tag == "Spring" || col.gameObject.tag == "Toge")
            {
                _ene.command = enemy.status.rotate;
            }
        
    }
}
