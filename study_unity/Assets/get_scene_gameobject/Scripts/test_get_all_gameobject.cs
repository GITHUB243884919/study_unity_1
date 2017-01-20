/// <summary>
/// date ： 2016-02-29
/// 示范得到场景中gameobject的几种方法
/// </summary>
using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UEngine;

public class test_get_all_gameobject : MonoBehaviour 
{

	// Use this for initialization
	void Start ()
	{
        Debug.Log(string.Format("Type : {0} doesn't contains \"path\" field.", "235"));
	    GameObject []  allGos = Common.GetAllGameObjectInScene(false);
	    foreach (GameObject go in allGos)
	    {
	        Debug.Log(go.name);
	    }
	    
        Debug.Log("========================");
	    
        GameObject[] allActiveGos = Common.GetAllActiveGameObjectInScene(false);
        foreach (GameObject go in allActiveGos)
        {
            Debug.Log(go.name);
        }


	    
	}
	
}
#endif