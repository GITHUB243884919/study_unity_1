/// <summary>
/// date ： 2016-02-29
/// 示范GetPrefabAssetPath这个工具函数在运行状态下是无效的
/// </summary>
using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UEngine;

public class test_get_prefab_assetpath : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    //string path = Common.GetPrefabAssetPath(gameObject);
	    //Debug.Log(path);
        GameObject[] allGos = Common.GetAllActiveGameObjectInScene(false);
        foreach (GameObject go in allGos)
        {
            string path = Common.GetPrefabAssetPath(go);
            Debug.Log(path);

        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
#endif