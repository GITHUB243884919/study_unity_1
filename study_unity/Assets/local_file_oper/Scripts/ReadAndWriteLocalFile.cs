/// <summary>
/// date :2016-03-02
/// 本地文件操作示例
/// 其中包含从stream文件夹读ab文件中的文本,并以文件的形式写到Application.persistentDataPath中
/// 当做资源管理时，需要从服务器获得现在所有资源的版本号和本地的对比。
/// 假设所有资源的号都保存在服务器一个xml文件中，当程序启动后首先就要获取的这个文件进行读取并和本地的这个文件对比
/// 然后再根据需要下载资源，资源下载完毕后要更新这个xml文件
/// 
/// date:2016-03-11
/// 增加GetAssetListVersionFromResource()
/// 示范从Resources读txt的第一行，并转化成int 包含try catch finally的使用
/// </summary>

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;
using System;
using UEngine;

public class ReadAndWriteLocalFile : MonoBehaviour
{

	// Use this for initialization
	void  Start ()
	{

	    GetAssetListVersionFromResource();
	    StartCoroutine(testReadAndWriteOnAndiod());
	    //ReadFromResources();


	}

    IEnumerator ReadAndWriteOnPC()
//#if UNITY_STANDALONE_WIN || UNITY_EDITOR
    {
        Text textComponent = GetComponent<Text>();
        List<string> fileData = LoadFile(Application.streamingAssetsPath, "/my.xml", textComponent);
        foreach (string s in fileData)
        {
            Debug.Log(s);
            textComponent.text += s;
        }

        yield return new WaitForSeconds(10.0f); 

        CreateFile(Application.streamingAssetsPath, "/my2.xml", "fanzhengyong");
        List<string> fileData2 = LoadFile(Application.streamingAssetsPath, "/my2.xml", textComponent);
        foreach (string s in fileData2)
        {
            Debug.Log(s);
            textComponent.text = s;
        }
    }


    /// <summary>
    /// 安卓下读StreamingAssets下的文本文件,并写到Application.persistentDataPath目录
    /// 1.用AB打包到项目目录下Resources下的my.xml 打包到StreamingAssets目录下，参数要指定Android平台
    /// 2.用www下载指定的AB名称,这里打包时就指定好了名称是my.xml.bundle
    /// 3.LoadAsset的时候不带扩展名.这里本来资源是my.xml但LoadAsset用的是my.估计只有文本文件才是这样的
    /// 4.LoadAsset后要as TextAsset 当然，接收也是TextAsset类型
    /// 5.这个函数可以在PC下用，但是本地路径要前要加 "file://" ，否则报host错
    /// 6.在安卓下打包需要把Player Setting里面选择WriteAccess -》External(SDCard)
    /// External(SDCard)：表示Application.persistentDataPath的路径是SDCard的路径。（不需要root就可以访问文件）
    /// 文件路径：SDCard/Android/包名/Files/我的文件
    /// </summary>
    /// <returns></returns>
    IEnumerator testReadAndWriteOnAndiod()
    {
        Text textComponent = GetComponent<Text>();
#if UNITY_ANDROID
		string path =    Application.streamingAssetsPath + "/my.xml.bundle";
#elif UNITY_IPHONE
        string path=     Application.dataPath + "/Raw/";
#elif UNITY_STANDALONE_WIN || UNITY_EDITOR
        string path = "file://" + Application.streamingAssetsPath + "/my.xml.bundle";
#endif

        using (WWW www = new WWW(path))
        {
            yield return www;

            if (www.error != null)
            {
                throw new Exception("WWW download had an error:" + www.error);
            }
                
            if (www.isDone)
            {
                AssetBundle assetbundle = www.assetBundle;
                //read
                TextAsset txt = assetbundle.LoadAsset("my", typeof(TextAsset)) as TextAsset;
                textComponent.text = txt.text;
                //write
                byte[]  data    = www.bytes;
                //int       length = data.Length;
                //textComponent.text = Application.persistentDataPath;
                string targetPath = Application.persistentDataPath;
                Debug.Log(targetPath);
                Common.CreateAssetbundleFile(targetPath, "my.xml.bundle", data);
                DestroyImmediate(txt, true);
                assetbundle.Unload(false);
            }
            
        }
    }


    /// <summary>
    /// 在项目目录的Resources目录下读文本文件
    /// 注意不需要扩展名
    /// 如果出现重名（重名但扩展名不同），PC和安卓上测试得到的后创建的那个文件
    /// </summary>
    void ReadFromResources()
    {
        Text textComponent = GetComponent<Text>();

        TextAsset bindata = Resources.Load("my") as TextAsset;
        if (bindata == null)
        {
            Debug.Log("null");
        }
        textComponent.text = bindata.text;
        Debug.Log(((TextAsset)Resources.Load("my")).text);
    }

    private bool GetAssetListVersionFromResource()
    {
        bool retCode = false;
        bool result = false;
        TextAsset textAsset = Resources.Load("asset") as TextAsset;
        if (textAsset == null)
        {
            return result;
        }

        int tempVersionID = 0;
        using (StringReader stringReader = new StringReader(textAsset.text))
        {
            string firstLine = stringReader.ReadLine();
            retCode = Common.String2Int32(firstLine, ref tempVersionID);
            if (retCode)
            {
                result = true;
            }  
        }


        //try
        //{
        //    tempVersionID = Convert.ToInt32(firstLine);
        //    Debug.Log(tempVersionID);
        //    result = true;
        //}
        //catch (Exception e)
        //{
        //    Debug.Log(e.Message);
        //}
        //finally
        //{
        //    Debug.Log("finally");
        //    if (stringReader != null)
        //    {
        //        stringReader.Dispose();
        //    }
        //}

        Debug.Log(tempVersionID);
        Debug.Log(result);
        
        return result;

    }
    /// <summary>
    /// 读取文件.
    /// </summary>
    /// <returns>The file.</returns>
    /// <param name="path">完整文件夹路径.</param>
    /// <param name="name">读取文件的名称.</param>
    public List<string> LoadFile(string path, string name, Text textComponent)
    {
        //使用流的形式读取
        List<string> arrlist = new List<string>();
        StreamReader sr = null;
        try
        {
            sr = File.OpenText(path + name);
        }
        catch (Exception e)
        {
            //路径与名称未找到文件则直接返回空
            Debug.LogError(e.ToString());
            if (textComponent)
            {
                textComponent.text = e.ToString();
            }
            return arrlist;
        }
        string line;
        
        while ((line = sr.ReadLine()) != null)
        {
            //一行一行的读取
            //将每一行的内容存入数组链表容器中
            arrlist.Add(line);
        }
        //关闭流
        sr.Close();
        //销毁流
        sr.Dispose();
        //将数组链表容器返回
        return arrlist;
    }

    /// <summary>
    /// 创建文件.
    /// </summary>
    /// <param name="path">完整文件夹路径.</param>
    /// <param name="name">文件的名称.</param>
    /// <param name="info">写入的内容.</param>
    public void CreateFile(string path, string name, string info)
    {
        //文件流信息
        StreamWriter sw;
        FileInfo t = new FileInfo(path + name);
        if (!t.Exists)
        {
            //如果此文件不存在则创建
            sw = t.CreateText();
        }
        else
        {
            //如果此文件存在则打开
            sw = t.AppendText();
        }
        //以行的形式写入信息
        sw.WriteLine(info);
        //关闭流
        sw.Close();
        //销毁流
        sw.Dispose();
    }

}
