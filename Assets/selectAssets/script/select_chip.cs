using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class select_chip : MonoBehaviour {
    public Sprite P_null;
    public Sprite P_stageA;
    public Sprite P_stageB;
    public Sprite P_toge;
    public Sprite P_spring;
    public Sprite P_goalFlag;
    public Sprite P_player;
    public Sprite P_enemy;
    public Sprite P_enemyB_0;
    public Sprite P_enemyB_1;
    public Sprite P_flower;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetSprite(string spriteName)
    {
        Image image = GetComponent<Image>();
        switch (spriteName)
        {
            case "null":
                image.sprite = P_null;
                break;
            case "stageA":
                image.sprite = P_stageA;
                break;
            case "stageB":
                image.sprite = P_stageB;
                break;
            case "toge":
                image.sprite = P_toge;
                break;
            case "spring":
                image.sprite = P_spring;
                break;
            case "goalFlag":
                image.sprite = P_goalFlag;
                break;
            case "player":
                image.sprite = P_player;
                break;
            case "enemy":
                image.sprite = P_enemy;
                break;
            case "enemyB_0":
                image.sprite = P_enemyB_0;
                break;
            case "enemyB_1":
                image.sprite = P_enemyB_1;
                break;
            case "flower":
                image.sprite = P_flower;
                break;

            default:
                break;
        }
    }
}
