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
    private GameObject message;
    // Use this for initialization
    void Start () {
		
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
        if (password == again)
        {
            WWWForm form = new WWWForm();
            form.AddField("username", username);
            form.AddField("password", password);
            form.AddField("createtime", DateTime.Now.ToString());
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
                GameObject.Find("sceneChangeManager").GetComponent<sceneChangeManager>().ChangeScene("LoginScene");
            }
        }
        else
        {
            message.GetComponent<Text>().text = "パスワードが一致していません。";
        }
    }
}
