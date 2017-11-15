using UnityEngine;
using System.Collections;

public class editor_mapChip : MonoBehaviour {
    Animator aniCon;
    bool onPoint;
    public int mapX,mapY;
    editor_editManager manager;

    GameObject selectChipFrame;
    private int[,] map;

	// Use this for initialization
	void Start () {
        selectChipFrame = GameObject.Find("selectChipFrame");
        aniCon = GetComponent<Animator>();
        manager = GameObject.Find("EditManager").GetComponent<editor_editManager>();
        map = SaveStageData.Instance.GetStageDataFromNumber().ConvnertStageData();
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
        if (manager.setMapChipID == 5 && map[mapX, mapY] != 4)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    if (map[x,y] == 5)
                    {
                        map[x, y] = 0;
                    }
                }
            }
        }
        //ゴールをふたつもおかせねーぜ！
        if (manager.setMapChipID == 4 && map[mapX, mapY] != 5)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    if (map[x, y] == 4)
                    {
                        map[x, y] = 0;
                    }
                }
            }
        }
        if (map[mapX, mapY] != 5 && 
            map[mapX, mapY] != 4)
        {
            map[mapX, mapY] = manager.setMapChipID;
            Debug.Log("updateMap:Stage"+editor_editManager.stageID);
        }
            
    }
}
