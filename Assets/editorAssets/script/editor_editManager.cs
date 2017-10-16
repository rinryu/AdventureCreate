using UnityEngine;
using System.Collections;

public class editor_editManager : MonoBehaviour {

    public static int[,,] editMapData = new int[50, 10, 5];
    public static int stageID = 0;
    public static string Stagename;
    public static int[,] BGM_ID = new int[5, 5]
    {
        {-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1}
    };
    public static int[,] SE_ID = new int[6, 5]
    {
        {-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1}
    };
    public static int[,] value = new int[10, 5];
    public static int[,] effectID = new int[5, 5]
    {
        {-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1}
    };

    [SerializeField]
    public int setMapChipID;
    [SerializeField]
    public bool isDrag;

    [SerializeField] sceneChangeManager changeManager;

    private void Awake()
    {
        //for (int id = 0; id < editMapData.GetLength(2); id++)
        //{
        //    for (int iy = 0; iy < editMapData.GetLength(1); iy++)
        //    {
        //        for (int ix = 0; ix < editMapData.GetLength(0); ix++)
        //        {
        //            if (0 <= iy && iy <= 1)
        //            {
        //                editMapData[ix, iy, id] = 1;
        //            }
        //            if (2 <= iy && iy <= 9)
        //            {
        //                editMapData[ix, iy, id] = 0;
        //            }
        //        }
        //    }
        //}

        //for (int id = 0; id < editMapData.GetLength(2); id++)
        //{
        //    editMapData[2, 2, id] = 5;
        //}

        //for (int i = 0; i < BGM_ID.Length; i++)
        //{
        //    //BGM_ID[i,stageID] = -1;
        //}

        //for (int i = 0; i < SE_ID.Length; i++)
        //{
        //    //SE_ID[i, stageID] = -1;
        //}

    }
    // Use this for initialization
    void Start () {

        setMapChipID = 1;
        changeManager.LoadScene();
        
            
	}
	
	// Update is called once per frame
	void Update () {
        GetMouseCondition();
       // if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    Application.LoadLevel("gameScene");
       // }
        //Debug.Log(BGM_ID[0] +" : "+ BGM_ID[1] + " : " + BGM_ID[2] + " : " + BGM_ID[3]);
	}

    void GetMouseCondition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDrag = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDrag = false;
        }
    }
}
