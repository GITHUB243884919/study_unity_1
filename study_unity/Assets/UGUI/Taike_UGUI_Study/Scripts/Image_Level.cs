using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Image_Level : 
    MonoBehaviour,
    IBeginDragHandler,
    IEndDragHandler
{
    private Toggle[] toggles;
    private ScrollRect scrollRect;
    private int totalPage = 4;
    private float[] pagePostion;
    private float tagPos = 0.0f;
    private float slidingSpeed = 4;
    private bool slidingFlag = false;
    
    void Start ()
	{
	    scrollRect = GetComponent<ScrollRect>();
        Debug.Log(scrollRect.horizontalNormalizedPosition);
        Debug.Log(scrollRect.normalizedPosition);
        initPagePostion();
        InitToggle();
	}

    void initPagePostion()
    {
        pagePostion = new float[4];
        pagePostion[0] = 0.00f;
        pagePostion[1] = 0.33f;
        pagePostion[2] = 0.66f;
        pagePostion[3] = 1.00f;
    }

    void InitToggle()
    {
        toggles = new Toggle[4];
        toggles[0] = transform.parent.Find("Image_toggle_1").gameObject.GetComponent<Toggle>();
        toggles[0].onValueChanged.AddListener(OnToggle_1);

        toggles[1] = transform.parent.Find("Image_toggle_2").gameObject.GetComponent<Toggle>();
        toggles[1].onValueChanged.AddListener(OnToggle_2);

        toggles[2] = transform.parent.Find("Image_toggle_3").gameObject.GetComponent<Toggle>();
        toggles[2].onValueChanged.AddListener(OnToggle_3);

        toggles[3] = transform.parent.Find("Image_toggle_4").gameObject.GetComponent<Toggle>();
        toggles[3].onValueChanged.AddListener(OnToggle_4);


    }

    int CalcCurPage(ref float postion)
    {
        float offset = Mathf.Abs(postion - pagePostion[0]);
        int index = 0;
        Debug.LogFormat("input pos = {0}", postion);
        for (int i = 0; i < pagePostion.Length; i++)
        {
            float tempOffset = Mathf.Abs(postion - pagePostion[i]);
            Debug.LogFormat("{0} , tempOffset = {1}", i, tempOffset);
            if (tempOffset < offset)
            {
                index = i;
                offset = tempOffset;
            }
        }
        Debug.LogFormat("index = {0} ", index);
        postion = pagePostion[index];
        return index;
    }

	// Update is called once per frame
	void Update ()
	{
        if (slidingFlag)
        {
            scrollRect.horizontalNormalizedPosition = Mathf.Lerp(scrollRect.horizontalNormalizedPosition, tagPos, Time.deltaTime * slidingSpeed);
            if (Mathf.Abs(scrollRect.horizontalNormalizedPosition - tagPos) <= 0.001f)
            {
                Debug.LogFormat("<=0001f");
                slidingFlag = false;
            }
        }

	}

    public void OnBeginDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        slidingFlag = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        tagPos = scrollRect.horizontalNormalizedPosition;
        int index = CalcCurPage(ref tagPos);
        slidingFlag = true;
        toggles[index].isOn = true;
    }

    public void OnToggle_1(bool flag)
    {
        if (flag)
        {
            tagPos = pagePostion[0];
            slidingFlag = true;
        }
    }

    public void OnToggle_2(bool flag)
    {
        if (flag)
        {
            tagPos = pagePostion[1];
            slidingFlag = true;
        }
    }

    public void OnToggle_3(bool flag)
    {
        if (flag)
        {
            tagPos = pagePostion[2];
            slidingFlag = true;
        }
    }

    public void OnToggle_4(bool flag)
    {
        if (flag)
        {
            tagPos = pagePostion[3];
            slidingFlag = true;
        }
    }
}
