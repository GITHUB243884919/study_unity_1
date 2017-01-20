/// <summary>
/// date： 2016-03-08
/// 演示改变UI元素的位置(anchoredPosition)和大小(sizeDelta)
/// anchoredPosition 和 sizeDelta都和 pivot有关，位置是相对pivot的，改变大小是根据pivot来
/// </summary>
/// 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Image_Move_Resize_Test : MonoBehaviour 
{

	// Use this for initialization
	void Start ()
	{
	    Button buttonMove = transform.Find("Button_Move").gameObject.GetComponent<Button>();
	    buttonMove.onClick.AddListener(OnMove);

        Button buttonResize = transform.Find("Button_Resize").gameObject.GetComponent<Button>();
	    buttonResize.onClick.AddListener(OnResize);

       
	}

    void OnMove()
    {
        Debug.Log("111");
        RectTransform rectTransform = transform.Find("Image_1").gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition += new Vector2(10, 0);

    }

    void OnResize()
    {
        RectTransform rectTransform = transform.Find("Image_1").gameObject.GetComponent<RectTransform>();
        rectTransform.sizeDelta += new Vector2(10, 10);
        
    }
	
}
