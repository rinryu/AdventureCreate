using UnityEngine;
using System.Collections;

public class selectGlobal_selectChipManager : MonoBehaviour {
    public int stageID;
    public GameObject select_mapChip;
	// Use this for initialization
	void Start () {
        //CreateMap();
//        StartCoroutine("streamingCreateMap");
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public IEnumerator streamingCreateMap(int[,] stagedata)
    {
        int[,] map = GetAllStageData.Instance.GetSelectStageData.ConvertStageData();

        for (int y = 9; y > -1; y--)
        {
            for (int x = 0; x < 28; x++)
            {

                GameObject mapChip = Instantiate(select_mapChip) as GameObject;
                mapChip.transform.parent = this.transform;
                mapChip.transform.localScale = Vector3.one;
                switch (stagedata[x, 9 - y])
                {
                    case 0:
                        mapChip.GetComponent<select_chip>().SetSprite("null");
                        break;
                    case 1:
                        if (8 > y)
                        {
                            if (stagedata[x, (8 - y) + 1] != 1)
                            {
                                mapChip.GetComponent<select_chip>().SetSprite("stageA");
                            }
                            else
                            {
                                mapChip.GetComponent<select_chip>().SetSprite("stageB");
                            }
                        }
                        else
                        {
                            mapChip.GetComponent<select_chip>().SetSprite("stageB");
                        }

                        break;
                    case 2:
                        mapChip.GetComponent<select_chip>().SetSprite("toge");
                        break;
                    case 3:
                        mapChip.GetComponent<select_chip>().SetSprite("spring");
                        break;
                    case 4:
                        mapChip.GetComponent<select_chip>().SetSprite("goalFlag");
                        break;
                    case 5:
                        mapChip.GetComponent<select_chip>().SetSprite("player");
                        break;
                    case 6:
                        mapChip.GetComponent<select_chip>().SetSprite("enemy");
                        break;
                    case 7:
                        mapChip.GetComponent<select_chip>().SetSprite("enemyB_0");
                        break;
                    case 8:
                        mapChip.GetComponent<select_chip>().SetSprite("enemyB_1");
                        break;
                    case 9:
                        mapChip.GetComponent<select_chip>().SetSprite("flower");
                        break;
                    default:
                        break;
                }
                yield return null;
            }
        }
        yield return null;
    }//***CT_END
}
