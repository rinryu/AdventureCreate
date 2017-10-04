using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class editor_mapChipFrame : MonoBehaviour {

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


    GameObject[] mapChip = new GameObject[50 * 10];
    Image[] mapChip_image = new Image[50 * 10];
    // Use this for initialization
    void Start()
    {
        stageSlider = GameObject.Find("stageSlider").GetComponent<Slider>();

        SetChipObject();
        UpDateMap();
    }

    void SetChipObject()
    {
        for (int iy = 0; iy < 10; iy++)
        {
            for (int ix = 0; ix < 50; ix++)
            {
                int i = ix + iy * 50;
                mapChip[i] = Instantiate(P_mapChip) as GameObject;
                mapChip_image[i] = mapChip[i].GetComponent<Image>();
                mapChip[i].transform.parent = transform;
                mapChip[i].transform.localPosition = new Vector2(-1225 + 50 * ix, -225 + 50 * iy);
                mapChip[i].transform.localScale = Vector2.one;
                mapChip[i].GetComponent<editor_mapChip>().mapX = ix;
                mapChip[i].GetComponent<editor_mapChip>().mapY = iy;
            }
        }
    }

    //マップを書き替える
    void UpDateMap()
    {
        int mapSizeX = editor_editManager.editMapData.GetLength(0);
        int mapSizeY = editor_editManager.editMapData.GetLength(1);

        for (int iy = 0; iy < mapSizeY ; iy++)
        {
            for (int ix = 0; ix < mapSizeX; ix++)
            {
                if (editor_editManager.editMapData[ix,iy,editor_editManager.stageID] == 0)
                {
                    mapChip_image[ix + iy * mapSizeX].sprite = P_null;
                }
                if (editor_editManager.editMapData[ix, iy, editor_editManager.stageID] == 1)
                {
                    if (iy < mapSizeY - 1)
                    {
                        if (editor_editManager.editMapData[ix, iy + 1, editor_editManager.stageID] == 1)
                        {
                            mapChip_image[ix + iy * mapSizeX].sprite = P_stageB;
                        }
                        else
                        {
                            mapChip_image[ix + iy * mapSizeX].sprite = P_stageA;
                        }
                    }
                    else
                    {
                        mapChip_image[ix + iy * mapSizeX].sprite = P_stageA;
                    }
                    
                }
                if (editor_editManager.editMapData[ix, iy, editor_editManager.stageID] == 2)
                {
                    mapChip_image[ix + iy * mapSizeX].sprite = P_toge;
                }
                if (editor_editManager.editMapData[ix, iy, editor_editManager.stageID] == 3)
                {
                    mapChip_image[ix + iy * mapSizeX].sprite = P_spring;
                }
                if (editor_editManager.editMapData[ix, iy, editor_editManager.stageID] == 4)
                {
                    mapChip_image[ix + iy * mapSizeX].sprite = P_goalFlag;
                }
                if (editor_editManager.editMapData[ix, iy, editor_editManager.stageID] == 5)
                {
                    mapChip_image[ix + iy * mapSizeX].sprite = P_player;
                }
                if (editor_editManager.editMapData[ix, iy, editor_editManager.stageID] == 6)
                {
                    mapChip_image[ix + iy * mapSizeX].sprite = P_enemyA;
                }
                if (editor_editManager.editMapData[ix, iy, editor_editManager.stageID] == 7)
                {
                    mapChip_image[ix + iy * mapSizeX].sprite = P_enemyB_0;
                }
                if (editor_editManager.editMapData[ix, iy, editor_editManager.stageID] == 8)
                {
                    mapChip_image[ix + iy * mapSizeX].sprite = P_enemyB_1;
                }
                if (editor_editManager.editMapData[ix, iy, editor_editManager.stageID] == 9)
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
        UpDateMap();
        transform.localPosition = Vector2.zero - Vector2.right * stageSlider.value * 1730.0f;
    }
}
