using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Login : MonoBehaviour {

    [SerializeField]
    private GameObject inputUsername;
    [SerializeField]
    private GameObject inputPassword;
    [SerializeField]
    private GameObject text;
    [SerializeField]
    private sceneChangeManager sceneManager;
	// Use this for initialization
	void Start () {
        sceneManager.LoadScene();
        for (int id = 0; id < editor_editManager.editMapData.GetLength(2); id++)
        {
            for (int iy = 0; iy < editor_editManager.editMapData.GetLength(1); iy++)
            {
                for (int ix = 0; ix < editor_editManager.editMapData.GetLength(0); ix++)
                {
                    if (0 <= iy && iy <= 1)
                    {
                        editor_editManager.editMapData[ix, iy, id] = 1;
                    }
                    if (2 <= iy && iy <= 9)
                    {
                        editor_editManager.editMapData[ix, iy, id] = 0;
                    }
                }
            }
        }

        for (int id = 0; id < editor_editManager.editMapData.GetLength(2); id++)
        {
            editor_editManager.editMapData[2, 2, id] = 5;
        }

        for (int i = 0; i < editor_editManager.BGM_ID.Length; i++)
        {
            //BGM_ID[i,stageID] = -1;
        }

        for (int i = 0; i < editor_editManager.SE_ID.Length; i++)
        {
            //SE_ID[i, stageID] = -1;
        }

#if UNITY_EDITOR && DEVELOP
        StartCoroutine(LoginConnect("tester1", "tester1"));
#endif


    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnButtonDown()
    {
        StartCoroutine(LoginConnect());
    }

    IEnumerator LoginConnect()
    {
        string username = inputUsername.GetComponent<InputField>().text;
        string password = inputPassword.GetComponent<InputField>().text;
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);
        Dictionary<string, string> headers = form.headers;
        byte[] data = form.data;
        headers["Authorization"] = "Basic " + System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("adventurecreate:actest"));

        //      Dictionary<string, string> headers = form.headers;
        //        headers.Add("Authorization", "Basic " + System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("adventurecreate:actest")));
#if DEVELOP
        WWW result = new WWW(ServerSetting.DEVURL + "Login.php", data,headers);
#else
        WWW result = new WWW(ServerSetting.MASTERURL + "Login.php", form);
#endif
        yield return result;
        if (result.error == null)
        {
            text.GetComponent<Text>().text = result.text;
            if (result.text == "incorrect")
            {
                text.GetComponent<Text>().text = "Failue";
            }
            else 
            {
                Debug.Log(result.text);
                text.GetComponent<Text>().text = "Clear";
                UtilityBox.username = username;
                UtilityBox.userID = int.Parse(result.text);
                sceneManager.ChangeScene("titleScene");
                //SceneManager.LoadScene("UserInfo",LoadSceneMode.Additive);
            }
        }
        else
        {
            text.GetComponent<Text>().text = result.error;

        }
    }

    IEnumerator LoginConnect(string in_username,string in_password)
    {
        string username = in_username;
        string password = in_password;
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);
        Dictionary<string, string> headers = form.headers;
        byte[] data = form.data;
        headers["Authorization"] = "Basic " + System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("adventurecreate:actest"));

        //      Dictionary<string, string> headers = form.headers;
        //        headers.Add("Authorization", "Basic " + System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("adventurecreate:actest")));
#if DEVELOP
        WWW result = new WWW(ServerSetting.DEVURL + "Login.php", data, headers);
#else
        WWW result = new WWW(ServerSetting.MASTERURL + "Login.php", form);
#endif
        yield return result;
        if (result.error == null)
        {
            text.GetComponent<Text>().text = result.text;
            if (result.text == "incorrect")
            {
                text.GetComponent<Text>().text = "Failue";
            }
            else
            {
                Debug.Log(result.text);
                text.GetComponent<Text>().text = "Clear";
                UtilityBox.username = username;
                UtilityBox.userID = int.Parse(result.text);
                sceneManager.ChangeScene("titleScene");
                //SceneManager.LoadScene("UserInfo",LoadSceneMode.Additive);
            }
        }
        else
        {
            text.GetComponent<Text>().text = result.error;

        }
    }


    public void ChangeSignUp()
    {
        sceneManager.ChangeScene("SignUpScene");
    }
}
