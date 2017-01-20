/// <summary>
/// date ： 2016-02-29
/// 示范GetPrefabAssetPath
/// </summary>
using UnityEngine;
using System.Collections;
using UnityEditor;
using UEngine;

public class test_get_object_assetpath 
{

    [@MenuItem("my menu/get gameobject assetpath")]
	// Use this for initialization
	public static void  test_1() 
    {
        
        GameObject[] allGos = Common.GetAllActiveGameObjectInScene(false);
	    foreach (GameObject go in allGos)
	    {
	        string path = Common.GetPrefabAssetPath(go);
	        if (!string.IsNullOrEmpty(path))
	        {
                Debug.Log(path);
	        }
	    }
	}

    [@MenuItem("my menu/export_android_txt")]
    public static void testfunc2()
    {
        string tagetPath = Application.dataPath + "/StreamingAssets";
        BuildPipeline.BuildAssetBundles(tagetPath, 0, EditorUserBuildSettings.activeBuildTarget);
        //BuildPipeline.BuildAssetBundles(tagetPath);
    }
}
