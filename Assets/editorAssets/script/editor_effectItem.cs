using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class editor_effectItem : MonoBehaviour {

    public enum effectMode
    {
        goal,
        damage,
        attack,
    };
    public effectMode mode;


    public Sprite nullSprite;
    public Sprite[] effectSprites;

    int ID = -1;
    Image itemImage;

	// Use this for initialization
	void Start () {
        //*****//
        FirstSet();
        //******//


        itemImage = transform.FindChild("imageItems/item").GetComponent<Image>();
        SetSprite();
	}


    void FirstSet()
    {
        int _moedID = 0;
        switch (mode)
        {
            case effectMode.goal:
                _moedID = 0;
			ID = SaveStageData.Instance.GetSelectStageData.GoalEffect;
                break;
            case effectMode.damage:
                _moedID = 1;
			ID = SaveStageData.Instance.GetSelectStageData.DamageEffect;
                break;
            case effectMode.attack:
                _moedID = 2;
			ID = SaveStageData.Instance.GetSelectStageData.AttackEffect;
                break;
        }
//		ID = SaveStageData.Instance.GetSelectStageData.parameterData.effectID[_moedID];
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ButtonNext()
    {
        ID++;
        SetSprite();
    }
    public void ButtonBack()
    {
        ID--;
        SetSprite();
    }

    void SetSprite()
    {
        if (ID < -1)
        {
            ID = effectSprites.Length - 1;
        }
        if (effectSprites.Length - 1 < ID)
        {
            ID = -1;
        }

        if (ID != -1)
        {
            itemImage.sprite = effectSprites[ID];
        }
        else
        {
            itemImage.sprite = nullSprite;
        }

        //****データ同期*****//
        SendData();
        //******************//

    }

    void SendData()
    {
        int _ID = 0;
        switch (mode)
        {
            case effectMode.goal:
                _ID = 0;
			SaveStageData.Instance.GetSelectStageData.GoalEffect = ID;
			break;
            case effectMode.damage:
                _ID = 1;
			SaveStageData.Instance.GetSelectStageData.DamageEffect = ID;
			break;
            case effectMode.attack:
                _ID = 2;
			SaveStageData.Instance.GetSelectStageData.AttackEffect = ID;
			break;
        }
//		SaveStageData.Instance.GetSelectStageData.Parameter.effectID[_ID] = ID;

    }

    public void Reset()
    {
        ID = -1;
        SetSprite();
    }
}
