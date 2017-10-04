using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class editor_stageTag : MonoBehaviour {
    public int stageID = 0;
    public Sprite
        tag_0_push, tag_0_under,
        tag_1_push, tag_1_under,
        tag_2_push, tag_2_under,
        tag_3_push, tag_3_under,
        tag_4_push, tag_4_under
        ;
    Image[] tag = new Image[5];

    // Use this for initialization
    void Start () {
        for (int i = 0; i < 5; i++)
        {
            tag[i] = transform.FindChild("stage_" + i).gameObject.GetComponent<Image>();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetStageID(int ID)
    {
        tag[0].sprite = tag_0_under;
        tag[1].sprite = tag_1_under;
        tag[2].sprite = tag_2_under;
        tag[3].sprite = tag_3_under;
        tag[4].sprite = tag_4_under;
        if (ID == 0) tag[0].sprite = tag_0_push;
        if (ID == 1) tag[1].sprite = tag_1_push;
        if (ID == 2) tag[2].sprite = tag_2_push;
        if (ID == 3) tag[3].sprite = tag_3_push;
        if (ID == 4) tag[4].sprite = tag_4_push;
        stageID = ID;
        editor_editManager.stageID = ID;
    }
}
