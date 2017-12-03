using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StageButtonStatus : MonoBehaviour {
	public Sprite[] numSprite;

	public Image secondNum;
	public Image firstNum;

	public Text difficulty;
	public Text clearPercent;

	// Use this for initialization
	void Start () {
		difficulty.gameObject.SetActive (!GameParameter.instance.isGlobal);
		clearPercent.gameObject.SetActive (!GameParameter.instance.isGlobal);
		difficulty.text = StageDataClass.Difficulty.NORMAL.ToString ();
		clearPercent.text = "0";
	}
	public void SetActive(StageDataClass in_stage){
		Debug.LogError (numSprite [0].name);
		int stagenum = in_stage.StageNumber;
        SetFont(stagenum);
		difficulty.text = in_stage.difficulty.ToString ();
		clearPercent.text = in_stage.ClearPercent.ToString ();
	}
	public void SetActive(StageDataClass in_stage,int id){
		int stagenum = id;
        SetFont(stagenum);
		difficulty.text = in_stage.difficulty.ToString ();
		clearPercent.text = in_stage.ClearPercent.ToString ();
	}

    public void SetFont(int num)
    {
        secondNum.sprite = numSprite[num < 10 ? 0 : num/10];
        firstNum.sprite = numSprite[num % 10];
    }

    // Update is called once per frame
    void Update () {
		
	}
}
