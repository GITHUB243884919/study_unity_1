/// <summary>
/// date : 2016-03-01
/// 演示每隔一段时间显示点字 
/// </summary>

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class slow_show_text : MonoBehaviour
{
    private string willShowWord = "这是一段话，将以没秒5个字的速度显示。" +
                              "这是一段话，将以没秒5个字的速度显示。" +
                              "这是一段话，将以没秒5个字的速度显示。";

    private float speed = 5.0f;

    private Text text;
	// Use this for initialization
	void Start ()
	{
	    text = GetComponent<Text>();
	    StartCoroutine(showDlg());

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator showDlg()
    {
        float timeSum = 0.0f;
        while (text.text.Length < willShowWord.Length)
        {
            timeSum += speed * Time.deltaTime;
            text.text = willShowWord.Substring(0, System.Convert.ToInt32(timeSum));
            yield return null;
            //下面两个都行，貌似不带T的协程函数 return 什么都行
            //yield return 123;
            //yield return "fanzhengyong";
        }
        Debug.Log("flish");

    }
}
