using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollRectList : MonoBehaviour {

    private GameObject btnGo;
    private Button btnCom;
    private GameObject contentGo;
    private RectTransform contentRTF;
    //private Vector2 contentSize;
    void Start () 
    {
        btnGo  = transform.FindChild("Button").gameObject;
        btnCom = btnGo.GetComponent<Button>();
        btnCom.onClick.AddListener(OnBtnClick);

        contentGo = transform.FindChild("ScrollRect/Content").gameObject;
        contentRTF = contentGo.GetComponent<RectTransform>();
        //contentSize = contentRTF.sizeDelta;
	
	}
	
    void OnBtnClick()
    {
        Debug.Log("OnBtnClick");
        contentRTF.sizeDelta += new Vector2(0, 100);

    }

}
