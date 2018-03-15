using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System.IO;

public class MissingListWindow :EditorWindow {

    private static string[] extensions = { ".prefab", ".mat", ".controller", ".cs", ".mask", ".asset" };
    private static List<AssetParameterData> missingList = new List<AssetParameterData>();

    [MenuItem("Assets/MissingList")]
    private static void ShowMissingList()
    {

        Search();
        var window = GetWindow<MissingListWindow>();
        window.minSize = new Vector2(900, 300);
    }

    private static void Search()
    {
        string[] allPaths = AssetDatabase.GetAllAssetPaths();
        int length = allPaths.Length;

        for(int i = 0; i < length; i++)
        {
            EditorUtility.DisplayProgressBar("Serch Missing", string.Format("{0}/{1}", i + 1, length),(float)i/length);

            if (extensions.Contains(Path.GetExtension(allPaths[i])))
            {
                SearchMissing(allPaths[i]);
            }

        }

        EditorUtility.ClearProgressBar();
    }

    private static void SearchMissing(string path)
    {
        IEnumerable<UnityEngine.Object> assets = AssetDatabase.LoadAllAssetsAtPath(path);
        foreach(UnityEngine.Object obj in assets)
        {
            if(obj == null)
            {
                continue;
            }

            if(obj.name == "Deprecated EditorExtensionImpl")
            {
                continue;
            }

            SerializedObject sobj = new SerializedObject(obj);
            SerializedProperty property = sobj.GetIterator();

            while (property.Next(true))
            {
                if(property.propertyType== SerializedPropertyType.ObjectReference && property.objectReferenceValue == null && property.objectReferenceInstanceIDValue != 0)
                {
                    missingList.Add(new AssetParameterData()
                    {
                        obj = obj,
                        path = path,
                        property = property
                    });
                }
            }
        }
    }

    private Vector2 scrollPos;

    private void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Asset", GUILayout.Width(200));
        EditorGUILayout.LabelField("Property", GUILayout.Width(200));
        EditorGUILayout.LabelField("Path");
        EditorGUILayout.EndHorizontal();

        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);

        foreach(AssetParameterData data in missingList)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.ObjectField(data.obj, data.obj.GetType(), true, GUILayout.Width(200));
            EditorGUILayout.TextField(data.property.name, GUILayout.Width(200));
            EditorGUILayout.TextField(data.path);
            EditorGUILayout.EndHorizontal();


        }

        EditorGUILayout.EndScrollView();
    }

}
