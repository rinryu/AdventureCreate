using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageButton_Controller : MonoBehaviour {
    List<GameObject> stageButton = new List<GameObject>();
    List<Vector3>    firstScale  = new List<Vector3>();
    List<Vector3>    firstPos    = new List<Vector3>();
    GameObject       playButton;
    GameObject       makeButton;
    bool             isOpen      = false;
    public bool      isSelect    = false;
    public int       SelectID;
    [SerializeField] GameObject scrollbar;
    [SerializeField] private sceneChangeManager changeManager;
    
    // Use this for initialization
    void Start()
    {
        changeManager.LoadScene();
        int count = 0;
        while (true)
        {
            if (GameObject.Find("select_stageButton_" + count) ==null) break;
            stageButton.Add(GameObject.Find("select_stageButton_" + count));
            count++;
        }
		count = 0;
		foreach (GameObject obj in stageButton) {
			Debug.LogError (count);
			obj.GetComponent<StageButtonStatus>().SetActive(SaveStageData.Instance.Stage[count],count+1);
			count++;
		}
        stageButton.Add(scrollbar);
        playButton = transform.FindChild("Play").gameObject;
        makeButton = transform.FindChild("Make").gameObject;
        playButton.transform.localScale = Vector3.zero;
        makeButton.transform.localScale = Vector3.zero;

        for (int i = 0; i < stageButton.Count; i++)
        {
            firstPos.Add(stageButton[i].transform.position);
            firstScale.Add(stageButton[i].transform.localScale);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void OpenStageButton(int ID)
    {
        GameObject.Find("select_stageButton_" + ID).GetComponent<LayoutElement>().ignoreLayout = true;
        SaveStageData.Instance.stageID = ID;
        Debug.Log("Select " + SaveStageData.Instance.GetSelectStageData.StageName);
        SelectID = ID;
        isSelect = true;
        for (int i = 0; i < stageButton.Count; i++)
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
        List<Vector3> _firstPos = new List<Vector3>();
        List<Vector3> _firstScale = new List<Vector3>();
        for (int i = 0; i < stageButton.Count; i++)
        {
            _firstPos.Add(stageButton[i].transform.position);
            _firstScale.Add(stageButton[i].transform.localScale);
            
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
            for (int i = 0; i < stageButton.Count; i++)
            {

                stageButton[i].transform.position = _firstPos[i] + (firstPos[i] - _firstPos[i]) * f;
                stageButton[i].transform.localScale = _firstScale[i] + (firstScale[i] - _firstScale[i]) * f;
            }

            yield return null;
        }
        stageButton[SelectID].transform.SetSiblingIndex(SelectID);
        for (int i = 0; i < stageButton.Count; i++)
        {

            stageButton[i].transform.position = firstPos[i];
            stageButton[i].transform.localScale = firstScale[i];
            if (!stageButton[i].GetComponent<LayoutElement>()) continue;
            stageButton[i].GetComponent<LayoutElement>().ignoreLayout = false;
        }

        isSelect = false;
        isOpen = false;

        yield return null;
    }
}
