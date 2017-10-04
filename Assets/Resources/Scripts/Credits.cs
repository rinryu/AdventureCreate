using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Credits : MonoBehaviour {
    [SerializeField]
    bool isOpen = false;

    Vector3 firstpos;
	// Use this for initialization
	void Start () {
        firstpos = gameObject.transform.position;
        gameObject.transform.position = new Vector2(Screen.width * 100 ,Screen.height * 100);
	}
	
	// Update is called once per frame
	void Update () {
        if (isOpen)
        {
            gameObject.transform.position = firstpos;
            if (GetComponent<Image>().fillAmount <= 1 && transform.FindChild("Version").GetComponent<Text>().color.a <= 255)
            {
                GetComponent<Image>().fillAmount += Time.deltaTime * 2;
                transform.FindChild("Version").GetComponent<Text>().color = new Color(50,50,50,Time.deltaTime*100);
            }
        }
        if (!isOpen)
        {

                if (GetComponent<Image>().fillAmount >= 0 && transform.FindChild("Version").GetComponent<Text>().color.a >= 0)
                    GetComponent<Image>().fillAmount -= Time.deltaTime * 2;
                    transform.FindChild("Version").GetComponent<Text>().color = new Color(50, 50, 50, 255/Time.deltaTime*100);
            }
            if (GetComponent<Image>().fillAmount == 0)
                gameObject.transform.position = new Vector2(Screen.width * 100, Screen.height * 100);
        }

    public void Open()
    {
        isOpen = true;
    }

    public void Close()
    {
        isOpen = false;
    }
}
