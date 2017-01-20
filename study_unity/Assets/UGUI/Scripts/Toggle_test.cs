using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// date:2016-03-05
/// 单选示例
/// </summary>
public class Toggle_test : MonoBehaviour 
{

	// Use this for initialization
	void Start ()
	{
	    Toggle toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(OnChangeValue);

	}

    void OnChangeValue(bool value)
    {
        Debug.Log(value);
    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
