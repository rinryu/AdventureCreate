using UnityEditor;

public class CreateAssetBundle{

    [MenuItem("Assets/Buid AssetBundle")]
    static void BuildAllAssetBundles()
    {
        BuildPipeline.BuildAssetBundles("Assets/AssetBundle", BuildAssetBundleOptions.None, BuildTarget.WebGL);
    }
}
