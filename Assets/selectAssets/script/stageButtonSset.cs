using UnityEngine;
using System.Collections;

public class stageButtonSset : MonoBehaviour {
    GameObject[] stageButton = new GameObject[5];
    Vector3[] firstScale = new Vector3[5];
    Vector3[] firstPos = new Vector3[5];
    GameObject playButton;
    GameObject makeButton;
    bool isOpen = false;
    public bool isSelect = false;
	// Use this for initialization
	void Start () {
	    for (int i = 0; i < 5; i++)
        {
            stageButton[i] = transform.FindChild("select_stageButton_" + i).gameObject;
			stageButton [i].GetComponent<StageButtonStatus> ().SetActive (SaveStageData.Instance.Stage[i],i);
        }
        playButton = transform.FindChild("Play").gameObject;
        makeButton = transform.FindChild("Make").gameObject;
        playButton.transform.localScale = Vector3.zero;       
        makeButton.transform.localScale = Vector3.zero;

        for (int i = 0; i < 5; i++)
        {
            firstPos[i] = stageButton[i].transform.position;
            firstScale[i] = stageButton[i].transform.localScale;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OpenStageButton(int ID)
    {
        SaveStageData.Instance.stageID = ID;
        isSelect = true;
        for (int i = 0; i < 5; i++)
        {
            if (i == ID)
            {
                StartCoroutine("CT_Open", stageButton[i]);
                continue;
            }
            if (i != ID)
            {
                StartCoroutine("CT_Move", stageButton[i]);
            }
        }
        
    }

    IEnumerator CT_Open(GameObject _stageButton)
    {
        if (isOpen)
        {
            yield break;
        }
        isOpen = true;
        
        Vector3 originPos = new Vector3(Screen.width * 0.5f, Screen.height * 0.60f, 0);
        Vector3 firstPos = _stageButton.transform.position;

        _stageButton.transform.SetAsLastSibling();

        //OPEN
        for (float f = 0f; f < 1f; f += 4f * Time.deltaTime * 1.0f)
        {
            _stageButton.transform.position =
                firstPos + (originPos - firstPos) * f;
            _stageButton.transform.localScale = Vector3.one * 0.35f + Vector3.one * f * 0.35f;
            yield return null;
        }
        _stageButton.transform.position = originPos;
        _stageButton.transform.localScale = Vector3.one * 0.7f;

        for (float f = 0f; f < 1f; f += 4f * Time.deltaTime * 1.0f)
        {
            playButton.transform.localScale = Vector3.one * f;
            makeButton.transform.localScale = Vector3.one * f;
            yield return null;
        }
        

        //isOpen = false;
        yield return null;
        yield break;
    }
    IEnumerator CT_Move(GameObject _stageButton)
    {
        
        Vector3 firstPos = _stageButton.transform.position;
        Vector3 toPos = firstPos + Vector3.right * Screen.width * 0.7f;

        for (float f = 0f; f < 1f; f += 4.0f * Time.deltaTime * 1.0f)
        {
            _stageButton.transform.position = firstPos + (toPos - firstPos) * f;
            yield return null;
        }
        yield return null;
        yield break;
    }

    public void CloseStageButton()
    {
        StartCoroutine("CT_Close");
    }
    IEnumerator CT_Close()
    {
        Vector3[] _firstPos = new Vector3[5];
        Vector3[] _firstScale = new Vector3[5];
        for (int i = 0; i < 5; i++)
        {
            _firstPos[i] = stageButton[i].transform.position;
            _firstScale[i] = stageButton[i].transform.localScale;
        }
        for (float f = 0f; f < 1f; f += 6f * Time.deltaTime * 1.0f)
        {
            playButton.transform.localScale = Vector3.one * (1f - f);
            makeButton.transform.localScale = Vector3.one * (1f - f);
            yield return null;
        }
        playButton.transform.localScale = Vector3.zero;
        makeButton.transform.localScale = Vector3.zero;

        for (float f = 0f; f < 1f; f += 4f * Time.deltaTime * 1.0f)
        {
            for (int i = 0; i < 5; i++)
            {
                
                stageButton[i].transform.position =
                _firstPos[i] + (firstPos[i] - _firstPos[i]) * f;
                stageButton[i].transform.localScale = _firstScale[i] + (firstScale[i] - _firstScale[i]) * f;
            }
            
            yield return null;
        }
        for (int i = 0; i < 5; i++)
        {

            stageButton[i].transform.position =
            firstPos[i];
            stageButton[i].transform.localScale = firstScale[i];
        }
        
        isSelect = false;
        isOpen = false;
        yield return null;
    }
}
