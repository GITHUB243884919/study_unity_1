using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// date:2016-03-05
/// 多选示例， 注意其中一个OnChange会连带触发其他的，至少是其他的一个，合情合理：）
/// </summary>
public class ToggleGroup_test : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    GameObject select1Go1 = transform.Find("Toggle_1").gameObject;
	    Toggle toggle1 = select1Go1.GetComponent<Toggle>();
        toggle1.onValueChanged.AddListener(OnChangeValue1);

        GameObject select1Go2 = transform.Find("Toggle_2").gameObject;
        Toggle toggle2 = select1Go2.GetComponent<Toggle>();
        toggle2.onValueChanged.AddListener(OnChangeValue2);

        GameObject select1Go3 = transform.Find("Toggle_3").gameObject;
        Toggle toggle3 = select1Go3.GetComponent<Toggle>();
        toggle3.onValueChanged.AddListener(OnChangeValue3);


	}

    void OnChangeValue1(bool value)
    {
        Debug.LogFormat("toggle1 value{0}", value);
    }

    void OnChangeValue2(bool value)
    {
        Debug.LogFormat("toggle2 value{0}", value);
    }

    void OnChangeValue3(bool value)
    {
        Debug.LogFormat("toggle3 value{0}", value);
    }
}
