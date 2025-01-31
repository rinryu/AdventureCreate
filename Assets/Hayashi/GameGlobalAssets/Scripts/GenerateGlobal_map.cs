﻿using UnityEngine;
using System.Collections;

public class GenerateGlobal_map : MonoBehaviour
{ 
    /*
    public int[,] Map = new int[,] {
                                 //    0,1,2,3,4,5,6,7,8,9,10,                                                                        48,49
                                 {1,1,1,0,1,1,0,0,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},//0
                                 {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},//1
                                 {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},//2
                                 {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},//3
                                 {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},//4
                                 {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},//5
                                 {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},//6
                                 {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},//7
                                 {1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},//8
                                 {1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}//9
                                  };
    */

    /// <summary>
    /// Map
    /// </summary>

    int[,] Map;
    StageDataClass stage;
    int StageID;
    public int MapSizeX;
    public int MapSizeY;
    int TileSize = 50;

    /// <summary>
    /// Resource_Set
    /// </summary>
    /// 

    public AudioSource BGM;
    public AudioSource JumpSE;
    public AudioSource aSE;
    public AudioSource bSE;
    public AudioSource cSE;

    /// <summary>
    /// Effect
    /// </summary>
    bool startFlag = false;

    // Use this for initialization
    void Start()
    {
        stage = GetAllStageData.Stage[editor_editManager.stageID];
        Map =stage.CovnertStageData();
        ParameterData param = JsonUtility.FromJson<ParameterData>(stage.ConvertParameterData());
        param.PrintParam();
        GameObject.Find("GameParamater").GetComponent<GameParameter>().SetParam(param);
        GameObject.Find("GameParamater").GetComponent<GameParameter>().PrintParam();
        /*
        Map[0, 3] = 2;
        Map[1, 4] = 2;
    */
        MapSizeX = Map.GetLength(0);
       MapSizeY = Map.GetLength(1);
        StageID = editor_editManager.stageID;

        for (int x = 0; x < MapSizeX; x++){
            for (int y = 0; y < MapSizeY; y++){
                if (Map[x, y] == 1) {
                    if ( y != 9)
                    {
                        if (Map[x, y + 1] == 1 || Map[x, y + 1] == 2 || Map[x, y + 1] == 3)
                        {
                            GameObject Chip = Instantiate(Resources.Load<GameObject>("Prefabs/Tile"), new Vector2(x * TileSize, y * TileSize), Quaternion.identity) as GameObject;
                            Chip.transform.parent = GameObject.Find("_Object").transform;
                        }
                        else
                        {
                            GameObject Chip = Instantiate(Resources.Load<GameObject>("Prefabs/Tile2"), new Vector2(x * TileSize, y * TileSize), Quaternion.identity) as GameObject;
                            Chip.transform.parent = GameObject.Find("_Object").transform;
                        }
                    }
                    else
                    {
                        GameObject Chip = Instantiate(Resources.Load<GameObject>("Prefabs/Tile2"), new Vector2(x * TileSize, y * TileSize), Quaternion.identity) as GameObject;
                        Chip.transform.parent = GameObject.Find("_Object").transform;
                    }
                   
                }
                if (Map[x, y] == 2) {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("Prefabs/Toge"), new Vector2(x * TileSize, y * TileSize), Quaternion.identity)as GameObject;
                    Chip.transform.parent = GameObject.Find("_Object").transform;
                }
                if (Map[x, y] == 3)
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("Prefabs/Spring"), new Vector2(x * TileSize, y * TileSize), Quaternion.Euler(0,-90,0)) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Object").transform;
                }
                if (Map[x, y] == 4)//goal
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("Prefabs/Goal"), new Vector2(x * TileSize, y * TileSize), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Goal").transform;

                }
                if (Map[x, y] == 5)//chara
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("Prefabs/player"), new Vector2(x * TileSize, y * TileSize -30), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y] == 6)//monster
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("Prefabs/Monster"), new Vector2(x * TileSize, y * TileSize -20), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y] == 8)//???
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("Prefabs/MonsterB_0"), new Vector2(x * TileSize, y * TileSize ), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y] == 7)//???
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("Prefabs/MonsterB_1"), new Vector2(x * TileSize, y * TileSize), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y] == 9)//???
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("Prefabs/Flower"), new Vector2(x * TileSize, y * TileSize - 20), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Object").transform;
                }
                if (Map[x, y] == 10)//???
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("Prefabs/Monster"), new Vector2(x * TileSize, y * TileSize - 20), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y] == 11)//???
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("Prefabs/Monster"), new Vector2(x * TileSize, y * TileSize - 20), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y] == 12)//???
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("Prefabs/Monster"), new Vector2(x * TileSize, y * TileSize - 20), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y] == 13)//???
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("Prefabs/Monster"), new Vector2(x * TileSize, y * TileSize - 20), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }


            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //starteffect
        if (!startFlag)
        {
            Instantiate(Resources.Load<GameObject>("Prefabs/startEffect"));
            startFlag = true;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Chara_Move cm = GameObject.Find("player(Clone)").GetComponent<Chara_Move>();
            if (cm.GetisClear() || cm.GetisGameOver()) return;
            if (!GameParameter.isMenu) GameParameter.isMenu = true;
            else GameParameter.isMenu = false;
        }

    }

}
