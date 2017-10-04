using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class editor_soundBoxManager : MonoBehaviour {
    public GameObject _soundBox_SE;
    public GameObject _soundBox_BGM;
    /*
    public string[] BGM_name;
    public string[] SE_name;
    */
    GameObject[] soundBox_BGM;
    GameObject[] soundBox_SE;
    // Use this for initialization
    void Start () {
        /*
        soundBox_BGM = new GameObject[BGM_name.Length];
        soundBox_SE = new GameObject[SE_name.Length];
        for (int i = 0; i < soundBox_BGM.Length; i++)
        {
            soundBox_BGM[i] = Instantiate(_soundBox_BGM) as GameObject;
            soundBox_BGM[i].transform.parent = this.transform;
            soundBox_BGM[i].transform.localScale = Vector2.one;
            soundBox_BGM[i].transform.FindChild("name").GetComponent<Text>().text = BGM_name[i];
            soundBox_BGM[i].transform.localPosition = new Vector2(-Screen.width * 0.295f + i * Screen.width * 0.05f, Screen.height * 0.15f);
        }

        for (int i = 0; i < soundBox_SE.Length; i++)
        {
            soundBox_SE[i] = Instantiate(_soundBox_SE) as GameObject;
            soundBox_SE[i].transform.parent = this.transform;
            soundBox_SE[i].transform.localScale = Vector2.one;
            soundBox_SE[i].transform.FindChild("name").GetComponent<Text>().text = SE_name[i];
            
            soundBox_SE[i].transform.localPosition = new Vector2(-Screen.width * 0.195f + i * Screen.width * 0.08f, Screen.height * 0.15f);
        }
        */
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
