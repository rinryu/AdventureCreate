using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class editor_mapChipFrame : MonoBehaviour {

	public Transform frame;

    public GameObject P_mapChip;
    public Sprite P_null;
    public Sprite P_stageA;
    public Sprite P_stageB;
    public Sprite P_toge;
    public Sprite P_spring;
    public Sprite P_goalFlag;
    public Sprite P_player;
    public Sprite P_enemyA;
    public Sprite P_enemyB_0, P_enemyB_1;
    public Sprite P_flower;

    Slider stageSlider;

    [SerializeField]
    GameObject selectMapChipFrame;

    GameObject[] mapChip = new GameObject[50 * 10];
    Image[] mapChip_image = new Image[50 * 10];
	[SerializeField]
	public List<DeathPoint> deathPointList = new List<DeathPoint>();

    bool ready = false;

    public static int deplicateNumber = 0;
    [SerializeField]
    sceneChangeManager scenemanager;
    // Use this for initialization
    void Start()
    {
        stageSlider = GameObject.Find("stageSlider").GetComponent<Slider>();
        InitMap(false);
    }

    public void InitMap(bool isAlready,int num = 0)
    {
        if (isAlready)
        {
            deplicateNumber = num;
            ClearMap();
        }
        SaveStageData.Instance.GetDeathPoint((dp) => {
            SetChipObject();
            if (dp != null)
            {
                deathPointList = DeathPoint.SetMass(dp);
                SetHeatMap();
            }
            scenemanager.LoadScene();
            //UpDateMap();
        },num);

    }

    public void ShowDeathPoint()
    {
        scenemanager.CloseScene();
        InitMap(true, deplicateNumber);
    }

    public void ClearMap()
    {
        foreach(GameObject map in mapChip)
        {
            Destroy(map);
        }
    }

    void SetChipObject()
    {
        for (int iy = 0; iy < 10; iy++)
        {
            for (int ix = 0; ix < 50; ix++)
            {
                int i = ix + iy * 50;
                mapChip[i] = Instantiate(P_mapChip) as GameObject;
				mapChip[i].name = string.Format("mapChip[{0},{1}]",ix,iy);
                mapChip_image[i] = mapChip[i].GetComponent<Image>();
                mapChip[i].transform.parent = transform;
                mapChip[i].transform.localPosition = new Vector2(-1225 + 50 * ix, -225 + 50 * iy);
                mapChip[i].transform.localScale = Vector2.one;
                mapChip[i].GetComponent<editor_mapChip>().mapX = ix;
                mapChip[i].GetComponent<editor_mapChip>().mapY = iy;
                mapChip[i].GetComponent<editor_mapChip>().selectChipFrame = selectMapChipFrame;
            }
        }
        ready = true;
    }

	private void SetHeatMap(){
		string colormes = string.Empty;
        deathPointList.Sort((a, b) => b.mass - a.mass);

		foreach (DeathPoint dp in deathPointList) {
			Color color = new Color (1,1-((float)dp.mass) / deathPointList[0].mass, 1-((float)dp.mass) / deathPointList[0].mass);
			colormes = colormes + string.Format ("[{0},{1}]:color={2};", dp.posX,dp.posY, dp.mass);
			mapChip_image [dp.posX + dp.posY * 50].color = color; 
		}
		Debug.Log (colormes);
	}

    //マップを書き替える
    void UpDateMap()
    {
        int[,] map = SaveStageData.Instance.GetSelectStageData.ConvertStageData();
        int mapSizeX = map.GetLength(0);
        int mapSizeY = map.GetLength(1);

        for (int iy = 0; iy < mapSizeY ; iy++)
        {
            for (int ix = 0; ix < mapSizeX; ix++)
            {
                if (map[ix,iy] == 0)
                {
                    mapChip_image[ix + iy * mapSizeX].sprite = P_null;
                }
                if (map[ix, iy] == 1)
                {
                    if (iy < mapSizeY - 1)
                    {
                        if (map[ix, iy + 1] == 1)
                        {                            
							try{
                            	mapChip_image[ix + iy * mapSizeX].sprite = P_stageB;
							}
							catch(NullReferenceException e){
								string chipnum = string.Format ("map[{0},{1}]:", ix, iy);
								Debug.LogError (chipnum + e.Message);
							}
                        }
                        else
                        {
                            try
                            {
                                mapChip_image[ix + iy * mapSizeX].sprite = P_stageA;
                            }
                            catch (NullReferenceException e)
                            {
                                string chipnum = string.Format("map[{0},{1}]:", ix, iy);
                                Debug.LogError(chipnum + e.Message);
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            mapChip_image[ix + iy * mapSizeX].sprite = P_stageA;
                        }
                        catch (NullReferenceException e)
                        {
                            string chipnum = string.Format("map[{0},{1}]:", ix, iy);
                            Debug.LogError(chipnum + e.Message);
                        }
                    }

                }
                if (map[ix, iy] == 2)
                {
                    mapChip_image[ix + iy * mapSizeX].sprite = P_toge;
                }
                if (map[ix, iy] == 3)
                {
                    mapChip_image[ix + iy * mapSizeX].sprite = P_spring;
                }
                if (map[ix, iy] == 4)
                {
                    mapChip_image[ix + iy * mapSizeX].sprite = P_goalFlag;
                }
                if (map[ix, iy] == 5)
                {
                    mapChip_image[ix + iy * mapSizeX].sprite = P_player;
                }
                if (map[ix, iy] == 6)
                {
                    mapChip_image[ix + iy * mapSizeX].sprite = P_enemyA;
                }
                if (map[ix, iy] == 7)
                {
                    mapChip_image[ix + iy * mapSizeX].sprite = P_enemyB_0;
                }
                if (map[ix, iy] == 8)
                {
                    mapChip_image[ix + iy * mapSizeX].sprite = P_enemyB_1;
                }
                if (map[ix, iy] == 9)
                {
                    mapChip_image[ix + iy * mapSizeX].sprite = P_flower;
                    /*
                    if (iy < mapSizeY)
                    {
                        mapChip_image[ix + (iy + 1) * mapSizeX].sprite = P_stageA;
                    }
                    */
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ready)
        {
            UpDateMap();
        }
		transform.localPosition = frame.localPosition = Vector2.zero - Vector2.right * stageSlider.value * 1730.0f;
    }
}
