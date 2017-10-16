using UnityEngine;
using System.Collections;

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

    int[,,] Map;
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

    AssetBundle chipBundle;

    [SerializeField] sceneChangeManager changeManager;
    // Use this for initialization
    void Start()
    {
        Map = editor_editManager.editMapData;

        MapSizeX = Map.GetLength(0);
        MapSizeY = Map.GetLength(1);
        StageID = editor_editManager.stageID;

        StartCoroutine(LoadAssetBundle("file://" + Application.streamingAssetsPath + "/AssetBundle/gameobject", (s) =>
        {
            SetMap(s);
        }));


        GameParameter.DamageEffectID = editor_editManager.effectID[1, StageID];
        GameParameter.AttackEffectID = editor_editManager.effectID[2, StageID];
        if (GameObject.Find("BGM"))
        {
            GameObject.Find("BGM").GetComponent<AudioSource>().clip = GameParameter.BGM;
            GameObject.Find("BGM").GetComponent<AudioSource>().Play();

        }

        changeManager.LoadScene();

    }

    private void SetMap()
    {
        for (int x = 0; x < MapSizeX; x++)
        {
            for (int y = 0; y < MapSizeY; y++)
            {
                if (Map[x, y, StageID] == 1)
                {
                    if (y != 9)
                    {
                        if (Map[x, y + 1, StageID] == 1 || Map[x, y + 1, StageID] == 2 || Map[x, y + 1, StageID] == 3)
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
                if (Map[x, y, StageID] == 2)
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("Toge"), new Vector2(x * TileSize, y * TileSize), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Object").transform;
                }
                if (Map[x, y, StageID] == 3)
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("Spring"), new Vector2(x * TileSize, y * TileSize), Quaternion.Euler(0, -90, 0)) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Object").transform;
                }
                if (Map[x, y, StageID] == 4)//goal
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("Goal"), new Vector2(x * TileSize, y * TileSize), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Goal").transform;
                    GameParameter.goalEffectID = editor_editManager.effectID[0, StageID];

                }
                if (Map[x, y, StageID] == 5)//chara
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("player"), new Vector2(x * TileSize, y * TileSize - 30), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y, StageID] == 6)//monster
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("Monster"), new Vector2(x * TileSize, y * TileSize - 20), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y, StageID] == 8)//???
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("MonsterB_0"), new Vector2(x * TileSize, y * TileSize), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y, StageID] == 7)//???
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("MonsterB_1"), new Vector2(x * TileSize, y * TileSize), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y, StageID] == 9)//???
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("Flower"), new Vector2(x * TileSize, y * TileSize - 20), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Object").transform;
                }
                if (Map[x, y, StageID] == 10)//???
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("Monster"), new Vector2(x * TileSize, y * TileSize - 20), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y, StageID] == 11)//???
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("Monster"), new Vector2(x * TileSize, y * TileSize - 20), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y, StageID] == 12)//???
                {
                    GameObject Chip = Instantiate(Resources.Load<GameObject>("Monster"), new Vector2(x * TileSize, y * TileSize - 20), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y, StageID] == 13)//???
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
                if (Map[x, y, StageID] == 1)
                {
                    if (y != 9)
                    {
                        if (Map[x, y + 1, StageID] == 1 || Map[x, y + 1, StageID] == 2 || Map[x, y + 1, StageID] == 3)
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
                if (Map[x, y, StageID] == 2)
                {
                    GameObject Chip = Instantiate(in_chipBundle.LoadAsset<GameObject>("Toge"), new Vector2(x * TileSize, y * TileSize), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Object").transform;
                }
                if (Map[x, y, StageID] == 3)
                {
                    GameObject Chip = Instantiate(in_chipBundle.LoadAsset<GameObject>("Spring"), new Vector2(x * TileSize, y * TileSize), Quaternion.Euler(0, -90, 0)) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Object").transform;
                }
                if (Map[x, y, StageID] == 4)//goal
                {
                    GameObject Chip = Instantiate(in_chipBundle.LoadAsset<GameObject>("Goal"), new Vector2(x * TileSize, y * TileSize), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Goal").transform;
                    GameParameter.goalEffectID = editor_editManager.effectID[0, StageID];

                }
                if (Map[x, y, StageID] == 5)//chara
                {
                    GameObject Chip = Instantiate(in_chipBundle.LoadAsset<GameObject>("player"), new Vector2(x * TileSize, y * TileSize - 30), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y, StageID] == 6)//monster
                {
                    GameObject Chip = Instantiate(in_chipBundle.LoadAsset<GameObject>("Monster"), new Vector2(x * TileSize, y * TileSize - 20), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y, StageID] == 8)//???
                {
                    GameObject Chip = Instantiate(in_chipBundle.LoadAsset<GameObject>("MonsterB_0"), new Vector2(x * TileSize, y * TileSize), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y, StageID] == 7)//???
                {
                    GameObject Chip = Instantiate(in_chipBundle.LoadAsset<GameObject>("MonsterB_1"), new Vector2(x * TileSize, y * TileSize), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y, StageID] == 9)//???
                {
                    GameObject Chip = Instantiate(in_chipBundle.LoadAsset<GameObject>("Flower"), new Vector2(x * TileSize, y * TileSize - 20), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Object").transform;
                }
                if (Map[x, y, StageID] == 10)//???
                {
                    GameObject Chip = Instantiate(in_chipBundle.LoadAsset<GameObject>("Monster"), new Vector2(x * TileSize, y * TileSize - 20), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y, StageID] == 11)//???
                {
                    GameObject Chip = Instantiate(in_chipBundle.LoadAsset<GameObject>("Monster"), new Vector2(x * TileSize, y * TileSize - 20), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y, StageID] == 12)//???
                {
                    GameObject Chip = Instantiate(in_chipBundle.LoadAsset<GameObject>("Monster"), new Vector2(x * TileSize, y * TileSize - 20), Quaternion.identity) as GameObject;
                    Chip.transform.parent = GameObject.Find("_Chara").transform;
                }
                if (Map[x, y, StageID] == 13)//???
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

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Chara_Move cm = GameObject.Find("player(Clone)").GetComponent<Chara_Move>();
            if (cm.GetisClear() || cm.GetisGameOver()) return;
            if (!GameParameter.isMenu) GameParameter.isMenu = true;
            else GameParameter.isMenu = false;
        }


    }


}
