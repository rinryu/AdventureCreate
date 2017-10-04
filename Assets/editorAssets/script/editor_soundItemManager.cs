using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class editor_soundItemManager : MonoBehaviour {

    public GameObject _soundItem_BGM;
    public GameObject _soundItem_SE;
    /*
    public Sprite[] itemIcon_BGM,itemIcon_SE;
    */

    GameObject[] soundItem_BGM = new GameObject[5];
    GameObject[] soundItem_SE = new GameObject[9];

    // Use this for initialization
    void Start () {
        /*
	    for (int i = 0; i < soundItem_BGM.Length; i++)
        {
            soundItem_BGM[i] = Instantiate(_soundItem_BGM) as GameObject;
            soundItem_BGM[i].transform.parent = this.transform;
            soundItem_BGM[i].transform.localScale = Vector2.one;
            soundItem_BGM[i].GetComponent<Image>().sprite = itemIcon_BGM[i];
            soundItem_BGM[i].transform.localPosition = new Vector2(-Screen.width * 0.3f + i * Screen.width * 0.05f, -Screen.height * 0.08f);
        }
        for (int i = 0; i < soundItem_SE.Length; i++)
        {
            soundItem_SE[i] = Instantiate(_soundItem_SE) as GameObject;
            soundItem_SE[i].transform.parent = this.transform;
            soundItem_SE[i].transform.localScale = Vector2.one;
            soundItem_SE[i].GetComponent<Image>().sprite = itemIcon_SE[i];
            soundItem_SE[i].transform.localPosition = new Vector2(-Screen.width * 0.3f + i * Screen.width * 0.05f, -Screen.height * 0.16f);
        }
        */
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
