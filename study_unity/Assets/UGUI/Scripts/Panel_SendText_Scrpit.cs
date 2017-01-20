using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// date：2016-03-07
/// 通过mask和ScrollRect以及和本代码配合动态修改Text的显示区域，fontsize应该不是真实的大小，这里50的汉字后面其实加了6.搞了好久才发现其实
/// 是这个不对。暂时不知道怎么取,貌似preferredHeight，preferredWidth
/// 需要注意的是text的重心需要在左上角，因为是往下拉伸
/// 接下来要解决到底怎么取字体的大小，以及聊天表情（目前的思路是检测到特殊字符后生成一个图片覆盖 http://forum.china.unity3d.com/thread-1586-1-1.html）
/// </summary>
public class Panel_SendText_Scrpit : MonoBehaviour
{
    private GameObject buttonGo;
    private Button buttonCom;

    //text相关变量
    private GameObject allMessageGo;
    private Text allMessageText;
    private RectTransform allMessageRectTrs;
    private int perRowWidth;
    private int iShow;
    // Use this for initialization
    void Start()
    {
        Init();
    }

    void Init()
    {
        buttonGo = transform.Find("Button").gameObject;
        buttonCom = buttonGo.GetComponent<Button>();
        buttonCom.onClick.AddListener(OnSendBtn);

        allMessageGo = transform.Find("Image/Text").gameObject;
        allMessageText = allMessageGo.GetComponent<Text>();
        allMessageRectTrs = allMessageGo.GetComponent<RectTransform>();

        Debug.LogFormat("fontSize={0}", allMessageText.font.fontSize);
        Debug.LogFormat("preferredHeight={0}", allMessageText.preferredHeight);
        Debug.LogFormat("preferredWidth={0}", allMessageText.preferredWidth);
        Debug.LogFormat("fontSize={0}", allMessageText.fontSize);
        perRowWidth = 11 * allMessageText.fontSize;
        Debug.LogFormat("perRowWidth = {0}", perRowWidth);

        iShow = 0;
    }


    void OnSendBtn()
    {
        string addMessage = "一二三四五六七八九十二";
        //string addMessage = iShow.ToString();
        int curLengh = (allMessageText.text.Length + addMessage.Length) * (allMessageText.fontSize);
        int curRow = (curLengh + (perRowWidth - 1))/perRowWidth;
        float curLineSpace = (curRow-1) * allMessageText.lineSpacing;
        float curHeigh = curRow * (allMessageText.fontSize + 6) + curLineSpace;
        //Debug.LogFormat("curRow = {0}, curLineSpace= {1}, curHeigh= {2}", curRow, curLineSpace, curHeigh);
        Debug.LogFormat("curRow = {0}, curLineSpace= {1}, curHeigh= {2}, ishow={3}", curRow, curLineSpace, curHeigh, iShow);

        allMessageRectTrs.sizeDelta = new Vector2(perRowWidth, curHeigh);
        allMessageText.text += addMessage;
        iShow++;
    }

}
