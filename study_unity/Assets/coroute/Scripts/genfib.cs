/// <summary>
/// date 2016-03-01
/// IEnumerator<T>的使用
/// T是yield return 的类型，不过就整体语法上看而言，其实外面的调用并没有接收return的结果，这让刚接触C#不久的人对这种
/// 语法有点困惑。不过想想他相当于c++的callback函数，其实就是被执行而已，一般也没有变量接收callback函数的结果。
/// 
/// </summary>
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class genfib : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        StartCoroutine(GenFib(10));
	    Debug.Log("go head, I am activing:)");
    }

    /// <summary>
    /// 生成斐波拉斯数列
    /// 有3点示例
    /// 1 可以用IEnumerator<T>指定类型，T是什么yield return 就可以是什么类型
    /// 2 yeild return 交控制权。这种很适合异步，比如IEnumerator 函数内部干活，把干的进度更新一个变量，这个变量能被外面读取（比如成员变量）
    ///    IEnumerator 函数没执行完之前不会让整个程序挂起
    /// 3 第一个yield return 0的作用是为了立刻把控制权交给外面，return 只要是int都行.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    IEnumerator<int> GenFib(int n)
    {
        Debug.Log("begin gen");
        yield return 0;
        new WaitForSeconds(3.0f);
        int a0 = 0;
        Debug.Log(a0);
        int a1 = 1;
        Debug.Log(a1);
        int current = 0;
        while ((n - 2) > 0)
        {
            current = a0 + a1;
            Debug.Log(current);
            yield return current;
            n--;
            a0 = a1;
            a1 = current;

        }
        Debug.Log("flish gen");

    }
}
