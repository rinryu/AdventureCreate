using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class sceneChangeManager : MonoBehaviour {
    Animator aniCon;
    bool isRunning;
	public static sceneChangeManager _Instance;


    public void LoadScene()
    {
        isRunning = false;
        aniCon = GetComponent<Animator>();
        aniCon.Play("sceneGate_open");
    }

    public void ChangeScene(string sceneName)
    {
        
        StartCoroutine("_ChangeScene", sceneName);
    }
    IEnumerator _ChangeScene(string _sceneName)
    {
        if (isRunning)
        {
            yield break;
        }
        transform.SetAsLastSibling();//一番手前に
        isRunning = true;
        yield return new WaitForSeconds(0.2f);
        aniCon.Play("sceneGate_close");
        yield return new WaitForSeconds(0.8f);
        isRunning = false;

        AsyncOperation async = SceneManager.LoadSceneAsync(_sceneName);
        async.allowSceneActivation = false;

        while(async.progress < 0.9f)
        {
            Debug.Log("Scene Loading...");

        }



        yield return null;
    }
}
