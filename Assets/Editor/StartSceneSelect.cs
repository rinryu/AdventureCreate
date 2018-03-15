using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System.Linq;
public class StartSceneSelect{

	[MenuItem("Tools/Play to selectedScene")]
	public static void OpenScene(){
		EditorApplication.LoadLevelInPlayMode("Assets/Hayashi/LoginAssets/LoginScene.unity");	
	}

}
