using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SceneBuildIndexCreatetor{

	private static readonly string[] INVALID_CHARS =
	{
		" ","!","\"","#","$",
		"%","&","\'","(",")",
		"-","=","^","~","\\",
		"|","[","{","@","`",
		"]","}",":","*",";",
		"+","/","?",".",">",
		",","<"
	};

	private const string ITEM_NAME = "Tools/BuildSetting/Craete SceneData";
	private const string  PATH = "Assets/Setting/SceneData.cs";

	private static readonly string FILENAME = Path.GetFileName(PATH);
	private static readonly string FILENAME_WITHOUT_EXTENSION = Path.GetFileNameWithoutExtension(PATH);



	[MenuItem(ITEM_NAME)]
	public static void Create(){

		if(!CanCreate()){
			return;
		}

		CreateScript();

		EditorUtility.DisplayDialog(FILENAME,"作成しました","OK");
	}

	public static void CreateScript(){
		var builder = new StringBuilder();

		builder.AppendLine("/// <summary>");
		builder.AppendLine("/// シーンのビルドインデックスを定数で管理するクラス");
		builder.AppendLine("///</summary>");
		builder.AppendFormat("public static class {0}",FILENAME_WITHOUT_EXTENSION).AppendLine();
		builder.AppendLine("{");

		foreach(var n in EditorBuildSettings.scenes
		.Select((val,index) => new {var = RemoveInvalidChars(Path.GetFileNameWithoutExtension(val.path)),val = index})){
			builder.Append("\t").AppendFormat(@"public const int {0} = {1};",n.var,n.val).AppendLine();			
		}

		builder.AppendLine("}");

		var directoryName = Path.GetDirectoryName(PATH);
		if(!Directory.Exists(directoryName)){
			Directory.CreateDirectory(directoryName);
		}
		File.WriteAllText(PATH,builder.ToString(),Encoding.UTF8);
		AssetDatabase.Refresh(ImportAssetOptions.ImportRecursive);
	}

	[MenuItem(ITEM_NAME,true)]
	public static bool CanCreate(){
		return !EditorApplication.isPlaying && !Application.isPlaying &&  !EditorApplication.isCompiling;
	}

	public static string RemoveInvalidChars(string str){
		Array.ForEach(INVALID_CHARS, c=> str = str.Replace(c, string.Empty));
		return str;
	}

}
