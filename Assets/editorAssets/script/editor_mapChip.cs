using UnityEngine;
using System.Collections;

public class editor_mapChip : MonoBehaviour {
    Animator aniCon;
    bool onPoint;
    public int mapX,mapY;
    editor_editManager manager;

    GameObject selectChipFrame;

	// Use this for initialization
	void Start () {
        selectChipFrame = GameObject.Find("selectChipFrame");
        aniCon = GetComponent<Animator>();
        manager = GameObject.Find("EditManager").GetComponent<editor_editManager>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (manager.isDrag && onPoint)
        {
            PushPoint();
        }
	}

    public void SetPoint(bool _bool)
    {
        if (_bool)
        {
            aniCon.SetBool("onPoint", true);
            transform.SetSiblingIndex(1000);
            selectChipFrame.transform.position = transform.position;
        }
        else
        {
            aniCon.SetBool("onPoint", false);
        }
        onPoint = _bool;
    }

    void PushPoint()
    {
        //プレイヤをふたつもおかせねーぜ！
        if (manager.setMapChipID == 5 && editor_editManager.editMapData[mapX, mapY, editor_editManager.stageID] != 4)
        {
            for (int y = 0; y < editor_editManager.editMapData.GetLength(1); y++)
            {
                for (int x = 0; x < editor_editManager.editMapData.GetLength(0); x++)
                {
                    if (editor_editManager.editMapData[x,y,editor_editManager.stageID] == 5)
                    {
                        editor_editManager.editMapData[x, y, editor_editManager.stageID] = 0;
                    }
                }
            }
        }
        //ゴールをふたつもおかせねーぜ！
        if (manager.setMapChipID == 4 && editor_editManager.editMapData[mapX, mapY, editor_editManager.stageID] != 5)
        {
            for (int y = 0; y < editor_editManager.editMapData.GetLength(1); y++)
            {
                for (int x = 0; x < editor_editManager.editMapData.GetLength(0); x++)
                {
                    if (editor_editManager.editMapData[x, y, editor_editManager.stageID] == 4)
                    {
                        editor_editManager.editMapData[x, y, editor_editManager.stageID] = 0;
                    }
                }
            }
        }
        if (editor_editManager.editMapData[mapX, mapY, editor_editManager.stageID] != 5 && 
            editor_editManager.editMapData[mapX, mapY, editor_editManager.stageID] != 4)
        {
            editor_editManager.editMapData[mapX, mapY, editor_editManager.stageID] = manager.setMapChipID;
            Debug.Log("updateMap:Stage"+editor_editManager.stageID);
        }
            
    }
}
