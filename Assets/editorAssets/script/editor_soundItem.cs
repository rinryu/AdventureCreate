using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class editor_soundItem : MonoBehaviour {
    public enum soundMode
    {
        BGM,
        SE,
    };

    public soundMode mode;
    editor_soundManager soundManager;

    bool isRunning;

    bool isDrag;
    public bool isApproach;

    bool BGMplaying;

    Vector2 firstPos;

    GameObject[] box = new GameObject[11];
    public GameObject setBox;

    public int ID;

    // Use this for initialization
    void Start () {
        BGMplaying = false;
        isRunning = false;
        soundManager = GameObject.Find("editor_sideSound").GetComponent<editor_soundManager>();
        isDrag = false;
        //firstPos = transform.position;
        //setBox = null;
        int count = 0;
        foreach (Transform child in GameObject.Find("soundBoxSet").transform)
        {
            box[count] = child.gameObject;
            count++;
        }
        for (int i = 0; i < 20; i++)
        {
            if (transform.name == "editor_soundItem_BGM_" + i)
            {
                ID = i;
            }
            if (transform.name == "editor_soundItem_SE_" + i)
            {
                ID = i;
            }
        }
        if (setBox == null)
        {
            Vector2 oPos = new Vector2(Screen.width * 0.77f, Screen.height * 0.365f);
            if (mode == soundMode.BGM)
            {
                firstPos = oPos + Vector2.right * Screen.width * 0.066f * (ID % 3) + Vector2.down * Screen.width * 0.066f * (ID / 3);
            }
            oPos = new Vector2(Screen.width * 0.07f, Screen.height * 0.365f);
            if (mode == soundMode.SE)
            {
                firstPos = oPos + Vector2.right * Screen.width * 0.033f * ID + Vector2.down * Screen.width * 0.055f * (ID % 2);
            }
        }
        

        //既にハメていた場合
        /*
        if (mode == soundMode.SE)
        {
            if (editor_editManager.SE_ID[ID] != -1)
            {
                setBox = GameObject.Find("editor_soundBox_SE_" + ID);
                transform.position = setBox.transform.position;
                setBox.GetComponent<editor_soundBox>().getItem = this.gameObject;
            }
        }
        if (mode == soundMode.BGM)
        {
            if (editor_editManager.BGM_ID[ID] != -1)
            {
                setBox = GameObject.Find("editor_soundBox_BGM_" + ID);
                transform.position = setBox.transform.position;
                setBox.GetComponent<editor_soundBox>().getItem = this.gameObject;
            }
        }
        */
    }
	
	// Update is called once per frame
	void Update () {
	    if (isDrag)
        {
            Drag();
        }
        if (!isDrag && !isApproach)
        {
            float step = Screen.width * Time.deltaTime * Vector2.Distance(transform.position,firstPos) * 0.007f;
            transform.position = Vector3.MoveTowards(transform.position, firstPos, step);
        }
    }

    void Drag()
    {
        Vector2 mousePos = new Vector2
            (
            Input.mousePosition.x,
            Input.mousePosition.y
            );
        if (isApproach)
        {
            if (setBox.GetComponent<editor_soundBox>().getItem != this.gameObject)
            {
                setBox.GetComponent<editor_soundBox>().getItem = this.gameObject;
            }
            transform.position = setBox.transform.position;
            //外す
            if (Vector2.Distance(mousePos, setBox.transform.position) >= Screen.width * 0.03f)
            {
                isApproach = false;
                setBox.GetComponent<editor_soundBox>().isSet = false;
                setBox.GetComponent<editor_soundBox>().getItem = null;
                setBox = null;
            }
        }
        else
        {
            transform.position = Input.mousePosition;
        }

        for (int i = 0; i < box.Length; i++)
        {
            if (Vector2.Distance(mousePos,box[i].transform.position) < Screen.width * 0.03f
                &&
                !box[i].GetComponent<editor_soundBox>().isSet)
            {
                if (mode == soundMode.BGM)
                {
                    if (box[i].GetComponent<editor_soundBox>().isBGM)
                    {
                        isApproach = true;
                        setBox = box[i];
                        setBox.GetComponent<editor_soundBox>().isSet = true;
                    }
                }
                if (mode == soundMode.SE)
                {
                    if (!box[i].GetComponent<editor_soundBox>().isBGM)
                    {
                        isApproach = true;
                        setBox = box[i];
                        setBox.GetComponent<editor_soundBox>().isSet = true;
                    }
                }
            }
        }
        
    }

    public void TouchStart()
    {
        isDrag = true;
        soundManager.isItemDrag = true;
        GetComponent<Shadow>().effectDistance = new Vector2(3, -3);
        transform.SetSiblingIndex(100);
        StartCoroutine("Punyon");

        
        if (mode == soundMode.SE)
        {
            GetComponent<AudioSource>().Play();
        }
        if (mode == soundMode.BGM)
        {
            GetComponent<AudioSource>().volume = 1.0f;
            GetComponent<AudioSource>().Play();
        }
    }
    public void TouchEnd()
    {
        isDrag = false;
        soundManager.isItemDrag = false;
        GetComponent<Shadow>().effectDistance = new Vector2(1, -1);

        if (mode == soundMode.BGM)
        {
            StartCoroutine("BGM_TestPlay");
        }
    }

    IEnumerator Punyon()
    {
        if (isRunning)
        {
            yield break;
        }
        float speed = 4.0f;
        isRunning = true;
        for(float f = 1.0f; f > 0.8f; f -= speed * Time.deltaTime)
        {
            transform.localScale = Vector2.one * f;
            yield return null;
        }
        for (float f = 0.8f; f < 1.2f; f += speed * Time.deltaTime)
        {
            transform.localScale = Vector2.one * f;
            yield return null;
        }
        for (float f = 1.2f; f > 1.0f; f -= speed * Time.deltaTime)
        {
            transform.localScale = Vector2.one * f;
            yield return null;
        }
        isRunning = false;
        transform.localScale = Vector2.one;
        yield return null;
    }

    IEnumerator BGM_TestPlay()
    {
        if (BGMplaying)
        {
            yield break;
        }
        BGMplaying = true;
        for (float f = 1.0f; f > 0.0f; f -= 1.0f * Time.deltaTime)
        {
            GetComponent<AudioSource>().volume = f;
            yield return null;
        }
        GetComponent<AudioSource>().volume = 0.0f;
        GetComponent<AudioSource>().Stop();
        yield return null;
        BGMplaying = false;
    }

    public void Reset()
    {
        if (isApproach)
        {
            transform.position = firstPos;
            isApproach = false;
            setBox.GetComponent<editor_soundBox>().isSet = false;
            setBox = null;
        }
    }
}
