using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class lifeManager : MonoBehaviour {
    public Sprite
        life_True,
        life_False
        ;
    public int 
        maxLife,
        life
        ;
    GameObject[] lifeObject = new GameObject[8];
    Image[] lifeImage = new Image[8];

    Vector2 firstPos;
    bool isRunnning;
    
	// Use this for initialization
	void Start () {
		maxLife = GameParameter.instance._LIFE;
        if(maxLife == 0)
        {
            maxLife = 1;
        }
        life = maxLife;


        isRunnning = false;
        firstPos = transform.position;
        lifeObject[0] = transform.FindChild("life").gameObject;
        for (int i = 1; i < maxLife; i++)
        {
            lifeObject[i] = Instantiate(lifeObject[0]) as GameObject;
            lifeObject[i].transform.parent = this.transform;
            lifeObject[i].transform.localScale = Vector3.one;
        }
        for (int i = 0; i < maxLife; i++)
        {
            lifeImage[i] = lifeObject[i].GetComponent<Image>();
        }
	}
	
	// Update is called once per frame
	void Update () {
	    for (int i = 0; i < maxLife; i++)
        {
            if (life > i)
            {
                lifeImage[i].sprite = life_True;
            }
            else
            {
                lifeImage[i].sprite = life_False;
            }
        }

	}

    public void GetDamage()
    {
        StartCoroutine("getDamage");
    }

    IEnumerator getDamage()
    {
        if (isRunnning)
        {
            yield break;
        }
        isRunnning = true;
        life--;
        Chara_Move.life--;
        for (float f = 1f; f > 0f; f -= 3.0f * Time.deltaTime)
        {
            transform.position = firstPos + new Vector2(
                Screen.width * 0.01f * Random.Range(-1f,1f) * f,
                Screen.width * 0.01f * Random.Range(-1, 1f) * f
                );
            yield return null;
        }
        transform.position = firstPos;
        isRunnning = false;
        yield return null;
    }
}
