using UnityEngine;
using System.Collections;

public class editor_soundManager : MonoBehaviour {
    public bool isOpen;
    public bool isItemDrag;
    public GameObject[] selectBox;
	// Use this for initialization
	void Start () {
        transform.localScale = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Open()
    {
        isOpen = true;
        transform.localScale = Vector3.one;

        GameObject[] box = new GameObject[11];
        
        int count = 0;
        foreach (Transform child in GameObject.Find("soundBoxSet").transform)
        {
            box[count] = child.gameObject;
            box[count].GetComponent<editor_soundBox>().FirstSetIn();
            count++;
        }
        
    }
    public void Close()
    {
        isOpen = false;
        transform.localScale = Vector3.zero;
    }

    public void AllReset()
    {
        GameObject[] item = new GameObject[29];
        int count = 0;
        foreach (Transform child in GameObject.Find("soundItemSet").transform)
        {
            item[count] = child.gameObject;
            item[count].GetComponent<editor_soundItem>().Reset();
            count++;
        }
        GameObject[] box = new GameObject[11];
        count = 0;
        foreach (Transform child in GameObject.Find("soundBoxSet").transform)
        {
            box[count] = child.gameObject;
            box[count].GetComponent<editor_soundBox>().isSet = false;
            box[count].GetComponent<editor_soundBox>().getItem = null;
            count++;
        }

    }

}
