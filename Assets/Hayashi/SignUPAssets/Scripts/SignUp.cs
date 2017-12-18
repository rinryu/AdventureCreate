using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SignUp : MonoBehaviour {

    [SerializeField]
    private GameObject inputUsername;
    [SerializeField]
    private GameObject inputPassword;
    [SerializeField]
    private GameObject inputPasswordAgain;
    [SerializeField]
    private GameObject inputTag;
    [SerializeField]
    private GameObject message;


    [SerializeField]
    private sceneChangeManager sceneManager;
    // Use this for initialization
    void Start () {
        sceneManager = GameObject.Find("sceneChangeManager").GetComponent<sceneChangeManager>();
        sceneManager.LoadScene();

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnButtonClick()
    {
        StartCoroutine(SignUPConnect());
    }

    IEnumerator SignUPConnect()
    {
        string username = inputUsername.GetComponent<InputField>().text;
        string password = inputPassword.GetComponent<InputField>().text;
        string again    = inputPasswordAgain.GetComponent<InputField>().text;
        string tag = inputTag.GetComponent<InputField>().text;


        if (password == again)
        {
            WWWForm form = new WWWForm();
            form.AddField("username", username);
            form.AddField("password", password);
            form.AddField("Tag", tag);
            Dictionary<string, string> headers = form.headers;
            byte[] data = form.data;
            headers["Authorization"] = "Basic " + System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("adventurecreate:actest"));
#if DEVELOP
            WWW www = new WWW(ServerSetting.DEVURL + "SignUp.php", data, headers);
#else
            WWW www = new WWW(ServerSetting.MASTERURL + "SignUp.php", form);
#endif
            yield return www;
            message.GetComponent<Text>().text = www.text;
            if (www.text == "success")
            {

                sceneManager.ChangeScene("titleScene");
            }
            else if(www.text == "failure")
            {

            }
        }
        else
        {
            message.GetComponent<Text>().text = "パスワードが一致していません。";
        }
    }
}
