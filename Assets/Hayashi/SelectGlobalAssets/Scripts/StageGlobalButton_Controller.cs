using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageGlobalButton_Controller : AC_Common {
    public GameObject button;
    public Transform buttonparent;
    public List<GameObject> stageButton = new List<GameObject>();
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
        stageButton.Add(scrollbar);

        firstPos.Add(scrollbar.transform.position);
        firstScale.Add(scrollbar.transform.localScale);
        GetAllStageData.Instance.GetAllStage(Callback);

        int count = 0;
        //while (true)
        //{
        //    if (GameObject.Find("select_stageButton_" + count) ==null) break;
        //    stageButton.Add(GameObject.Find("select_stageButton_" + count));
        //    count++;
        //}

        playButton = transform.FindChild("Play").gameObject;
        makeButton = transform.FindChild("Make").gameObject;
        playButton.transform.localScale = Vector3.zero;
        makeButton.transform.localScale = Vector3.zero;

        //for (int i = 0; i < stageButton.Count; i++)
        //{
        //    firstPos.Add(stageButton[i].transform.position);
        //    firstScale.Add(stageButton[i].transform.localScale);
        //}
    }

    public void Callback(List<StageDataClass> in_stageDataList)
    {
        int count = 1;
        foreach(StageDataClass stage in in_stageDataList)
        {
            GameObject obj = InstanciateObject(button, buttonparent);
            obj.name = "select_stageButton_" + stage.StageNumber;
            obj.GetComponent<StageSelectButton>().SetActive(stage,count);
			obj.GetComponent<StageButtonStatus> ().SetActive (stage,count);
            stageButton.Add(obj);
            firstPos.Add(obj.transform.position);
            firstScale.Add(obj.transform.localScale);
            count++;
        }
        button.SetActive(false);
        changeManager.LoadScene();
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void OpenStageButton(GameObject in_obj)
    {
        int ID = in_obj.GetComponent<StageSelectButton>().StageID;
        Debug.Log(ID);
        stageButton[ID].GetComponent<LayoutElement>().ignoreLayout = true;
        GetAllStageData.Instance.stageID = ID;
        SelectID = ID;
        isSelect = true;
        for (int i = 0; i < stageButton.Count; i++)
        {
            if (i == ID)
            {
                StartCoroutine("CT_Open", stageButton[i]);
                stageButton[i].GetComponent<StageSelectButton>().LoadStage();
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
        Debug.Log(stageButton.Count);
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
        Debug.Log(firstPos.Count);
        Debug.Log(firstScale.Count);
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
