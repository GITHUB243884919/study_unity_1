using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System;
using UEngine;

/// <summary>
/// date ：2016-03-12
/// 示范从StreamingAsset拷贝AB文件到persistentDataPath目录。
/// 在安卓手机上显然不成功，因为其实AB文件找不到，为什么？因为
/// 安装后的目录结构并不和apk一致。其实之前也做过测试，从
/// StreamingAsset上显然是不能直接读文本文件一致，只能WWW的方式
/// 读一个道理。最后得出结论从StreamingAsset目录是不能直接拷贝
/// 到手机，只能用之前的方式用WWW的方式读出来，然后再以文件的形式
/// 写到persistentDataPath
/// </summary>
public class CopyFileToPersistent : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    Button button = GetComponent<Button>();
	    button.onClick.AddListener(CopyTest);

	}

    void CopyTest()
    {
        string fileName = "my.xml.bundle";
        string sourcePath = Application.streamingAssetsPath;
        string targetPath = Application.persistentDataPath + "/test";
        Debug.Log(targetPath);

        try
        {
            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }
            File.Copy(sourcePath + "/" + fileName, targetPath + "/" + fileName, true);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            Common.MessageBox(e.Message);
        }
        
        
    }
}
