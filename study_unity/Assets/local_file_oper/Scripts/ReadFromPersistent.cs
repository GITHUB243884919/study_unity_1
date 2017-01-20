/// <summary>
/// date:2016-03-03
/// 示范www从 Application.persistentDataPath文件夹下读ab文件。注意路径前加"file:///"
/// 当没有文件时www.error并不会报错，但www.assetbundle == null，所以下载后一定要判断;
/// </summary>

using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ReadFromPersistent : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
        Button button = GetComponent<Button>();
	    button.onClick.AddListener(OnClick);

	}

    void OnClick()
    {
        Debug.Log("click");
        StartCoroutine(Read());
    }
    /// <summary>
    /// www方式读Application.persistentDataPath下的ab文件，注意路径前加"file:///"，安卓"file://"也行，但windows只能是"file:///"
    /// </summary>
    /// <returns></returns>
    IEnumerator Read()
    {
        GameObject go = transform.Find("Text").gameObject;
        Text textComponent = go.GetComponent<Text>();
        textComponent.text = "click";
#if UNITY_ANDROID
		string path =  "file://" + Application.persistentDataPath + "/my.xml.bundle";
#elif UNITY_IPHONE
        string path=     Application.dataPath + "/Raw/";
#elif UNITY_STANDALONE_WIN || UNITY_EDITOR
        string path = "file:///" + Application.persistentDataPath + "/my.xml.bundle";
#endif
        using (WWW www = new WWW(path))
        {
            yield return www;

            if (www.error != null)
            {
                textComponent.text = www.error;
                throw new Exception("WWW download had an error:" + www.error);
            }

            if (www.isDone)
            {
                textComponent.text = "down";
                AssetBundle assetbundle = www.assetBundle;
                //read
                if (assetbundle == null)
                {
                    textComponent.text = "assetbundle = null";
                }
                TextAsset txt = assetbundle.LoadAsset("my", typeof(TextAsset)) as TextAsset;
                if (txt == null)
                {
                    textComponent.text = "TextAsset txt == null";
                }
                textComponent.text = txt.text;
                Debug.Log(txt.text);
                DestroyImmediate(txt, true);
                assetbundle.Unload(false);
            }

        }
        
    }
}
