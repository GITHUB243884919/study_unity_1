/// <summary>
/// date 2016-03-01
/// 协程基本示例
/// 需要注意的是 WaitForSeconds这个需要new 网上有些例子没有new，估计是老版本是函数，现在看来人家是个类
/// </summary>

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class delay_destory : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
        StartCoroutine(DestoryMyself(3.0f));
	    Debug.Log("hello");
	}

    IEnumerator DestoryMyself(float waitSeconds)
    {
        //使用WaitForSeconds必须new
        Debug.Log("使用WaitForSeconds必须new");
        Debug.Log("yield return 后控制权立刻交到外面");
        Debug.Log("所以这三行会先打印");
        yield return new WaitForSeconds(waitSeconds);
        Destroy(gameObject);
        Debug.Log("world!");
    }



}
