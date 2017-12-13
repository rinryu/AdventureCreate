using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Generate_map : AC_Common
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
    int StageID;
    public int MapSizeX;
    public int MapSizeY;
    public const int TileSize = 50;

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

    AssetBundle chipBundle;

    [SerializeField] sceneChangeManager changeManager;
    // Use this for initialization
    void Awake()
    {
        StageID = SaveStageData.Instance.stageID;
		StageDataClass stage = SaveStageData.Instance.GetSelectStageData;
        Map = stage.ConvertStageData();
		ParameterData param = stage.parameterData;
		GameParameter.instance.SetParam(param);
        MapSizeX = Map.GetLength(0);
        MapSizeY = Map.GetLength(1);
#if STANDALONE
        string path = "file://" + Application.streamingAssetsPath + "/AssetBundle/gameobject";
#else 
        string path = ServerSetting.ASSETBUNDLEURL + "gameobject";
#endif
        StartCoroutine(LoadAssetBundle(path, (s) =>
        {
            SetMap(s);
            s.Unload(false);

        }));

        SaveStageData.Instance.GetDeathPoint((d)=>
        {
            SetDeathPoint(d);
        });

        if (GameObject.Find("BGM"))
        {
            GameObject.Find("BGM").GetComponent<AudioSource>().clip = GameParameter.instance.BGM;
            GameObject.Find("BGM").GetComponent<AudioSource>().Play();

        }

        changeManager.LoadScene();

    }

    private void SetDeathPoint(List<DeathPoint> deathPoints)
    {
        foreach(DeathPoint dp in deathPoints)
        {
            GameObject obj = Instantiate(Resources.Load("Prefabs/DeathPointMarker") as GameObject);
            //            GameObject obj = InstanciateObject("Prefabs", "DeathPointMarker", transform);
            Vector2 pos = new Vector2(dp.posX, dp.posY);
            if (pos.y <= 0) pos.y = 0;
            obj.transform.position = pos;
        }
        
    }

    private void SetMap()
    {
        for (int x = 0; x < MapSizeX; x++)
        {
            for (int y = 0; y < MapSizeY; y++)
            {
                if (Map[x, y] == 1)
                {
                    if (y != 9)
                    {
                        if (Map[x, y + 1] == 1 || Map[x, y + 1] == 2 || Map[x, y + 1] == 3)
                        {

                            GameObject Chip = Instantiate(Resources.Load<GameObject>("Prefabs/Tile"), new Vector2(x * TileSize, y * TileSize), Quaternion.identity) as GameObject;
                            Chip.transform.parent = GameObject.Find("_Object").transform;
                        }
                        else
                        {
                            GameObject Chip = Instantiate(Resources.Load<GameObject>("Tile2"), new Vector2(x * TileSize, y * TileSize), Quaternion.identity) as GameObject;
                            Chip.transform.parent = GameObject.Find("_Object").transform;
                        }
                    }
                    else
                    {
                        GameObject Chip = Instantiate(Resources.Load<GameObject>("Tile2"), new Vector2(x * TileSize, y * TileSize), Quaternion.identity) as GameObject;
                        Chip.transform.parent = GameObject.Find("_Object").transform;
                    }

                }
                if (Map[x, y] == 2)
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("Toge"), new Vector2(x * TileSize, y * TileSize), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Object").transform;
                }
                if (Map[x, y] == 3)
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("Spring"), new Vector2(x * TileSize, y * TileSize), Quaternion.Euler(0, -90, 0)) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Object").transform;
                }
                if (Map[x, y] == 4)//goal
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("Goal"), new Vector2(x * TileSize, y * TileSize), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Goal").transform;
                }
                if (Map[x, y] == 5)//chara
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("player"), new Vector2(x * TileSize, y * TileSize - 30), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y] == 6)//monster
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("Monster"), new Vector2(x * TileSize, y * TileSize - 20), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y] == 8)//???
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("MonsterB_0"), new Vector2(x * TileSize, y * TileSize), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y] == 7)//???
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("MonsterB_1"), new Vector2(x * TileSize, y * TileSize), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y] == 9)//???
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("Flower"), new Vector2(x * TileSize, y * TileSize - 20), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Object").transform;
                }
                if (Map[x, y] == 10)//???
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("Monster"), new Vector2(x * TileSize, y * TileSize - 20), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y] == 11)//???
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("Monster"), new Vector2(x * TileSize, y * TileSize - 20), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y] == 12)//???
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("Monster"), new Vector2(x * TileSize, y * TileSize - 20), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y] == 13)//???
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("Monster"), new Vector2(x * TileSize, y * TileSize - 20), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }


            }
        }

    }

    private void SetMap(AssetBundle in_chipBundle)
    {
        for (int x = 0; x < MapSizeX; x++)
        {
            for (int y = 0; y < MapSizeY; y++)
            {
                if (Map[x, y] == 1)
                {
                    if (y != 9)
                    {
                        if (Map[x, y + 1] == 1 || Map[x, y + 1] == 2 || Map[x, y + 1] == 3)
                        {
                            GameObject Chip = Instantiate(in_chipBundle.LoadAsset<GameObject>("Tile"), new Vector2(x * TileSize, y * TileSize), Quaternion.identity) as GameObject;
                            Chip.transform.parent = GameObject.Find("_Object").transform;

                        }
                        else
                        {
                            GameObject Chip = Instantiate(in_chipBundle.LoadAsset<GameObject>("Tile2"), new Vector2(x * TileSize, y * TileSize), Quaternion.identity) as GameObject;
                            Chip.transform.parent = GameObject.Find("_Object").transform;
                        }
                    }
                    else
                    {
                        GameObject Chip = Instantiate(in_chipBundle.LoadAsset<GameObject>("Tile2"), new Vector2(x * TileSize, y * TileSize), Quaternion.identity) as GameObject;
                        Chip.transform.parent = GameObject.Find("_Object").transform;
                    }

                }
                if (Map[x, y] == 2)
                {
                    GameObject Chip = Instantiate(in_chipBundle.LoadAsset<GameObject>("Toge"), new Vector2(x * TileSize, y * TileSize), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Object").transform;
                }
                if (Map[x, y] == 3)
                {
                    GameObject Chip = Instantiate(in_chipBundle.LoadAsset<GameObject>("Spring"), new Vector2(x * TileSize, y * TileSize), Quaternion.Euler(0, -90, 0)) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Object").transform;
                }
                if (Map[x, y] == 4)//goal
                {
                    GameObject Chip = Instantiate(in_chipBundle.LoadAsset<GameObject>("Goal"), new Vector2(x * TileSize, y * TileSize), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Goal").transform;

                }
                if (Map[x, y] == 5)//chara
                {
                    GameObject Chip = Instantiate(in_chipBundle.LoadAsset<GameObject>("player"), new Vector2(x * TileSize, y * TileSize - 30), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y] == 6)//monster
                {
                    GameObject Chip = Instantiate(in_chipBundle.LoadAsset<GameObject>("Monster"), new Vector2(x * TileSize, y * TileSize - 20), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y] == 8)//???
                {
                    GameObject Chip = Instantiate(in_chipBundle.LoadAsset<GameObject>("MonsterB_0"), new Vector2(x * TileSize, y * TileSize), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y] == 7)//???
                {
                    GameObject Chip = Instantiate(in_chipBundle.LoadAsset<GameObject>("MonsterB_1"), new Vector2(x * TileSize, y * TileSize), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y] == 9)//???
                {
                    GameObject Chip = Instantiate(in_chipBundle.LoadAsset<GameObject>("Flower"), new Vector2(x * TileSize, y * TileSize - 20), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Object").transform;
                }
                if (Map[x, y] == 10)//???
                {
                    GameObject Chip = Instantiate(in_chipBundle.LoadAsset<GameObject>("Monster"), new Vector2(x * TileSize, y * TileSize - 20), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y] == 11)//???
                {
                    GameObject Chip = Instantiate(in_chipBundle.LoadAsset<GameObject>("Monster"), new Vector2(x * TileSize, y * TileSize - 20), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y] == 12)//???
                {
                    GameObject Chip = Instantiate(in_chipBundle.LoadAsset<GameObject>("Monster"), new Vector2(x * TileSize, y * TileSize - 20), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y] == 13)//???
                {
                    GameObject Chip = Instantiate(in_chipBundle.LoadAsset<GameObject>("Monster"), new Vector2(x * TileSize, y * TileSize - 20), Quaternion.identity) as GameObject;
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

//        if (Input.GetKeyDown(KeyCode.Return))
//        {
//            Chara_Move cm = GameObject.Find("player(Clone)").GetComponent<Chara_Move>();
//            if (cm.GetisClear() || cm.GetisGameOver()) return;
//            if (!GameParameter.isMenu) GameParameter.isMenu = true;
//            else GameParameter.isMenu = false;
//        }


    }


}
