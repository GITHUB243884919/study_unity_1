/// <summary>
/// date：2016-03-17
/// 示范如何类外如何修改List<T>和Dictionary<T,T>的内容。
/// 把整个容器作为返回值返回外面，进行修改。
/// 
/// date :2016-03-18
/// 1、示范如何从类外如何修改Dictionary<string,GameObject>
/// 把Dictionary带出，在外面修改可以
/// 把GameObject带出，在外面修改可以
/// C#没有指针的概念，我猜测只要元素是引用类型的（System.Object的子类）都可以在外面改。
/// 怀疑值类型的和string不能直接改，得用一个class包起来当成System.Object的子类。
/// string应该就是System.Object的子类，但貌似每次都生成新的，所以也得包起来才能
/// 改。改天再试试。
/// 2、示范如何删除GameObject的脚本组件
/// 删除后还是立刻可以取到，但是在Update里才是取不到
/// The object obj will be destroyed now or if a time is specified t seconds 
/// from now. If obj is a Component it will remove the component from the 
/// GameObject and destroy it. If obj is a GameObject it will destroy the
/// GameObject, all its components and all transform children of the GameObject.
/// Actual object destruction is always delayed until after the current Update loop, 
/// but will always be done before rendering.
/// 物体obj现在被销毁或在指定了t时间过后销毁。如果obj是组件，它将从GameObject销毁组件component。
/// 如果obj是GameObject它将销毁GameObject全部它的组件和GameObject全部transform子物体。实际物
/// 体的销毁总是延迟到当前更新循环后，但总是渲染之前完成。
/// </summary>

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UEngine;

public class List_owner
{
    private List<int> m_list = new List<int>();

    public List_owner()
    {
        m_list.Add(1);
        m_list.Add(2);
    }
    public List<int> GetList()
    {
        return m_list;
    }

    public void PrintList()
    {
        foreach (int i in m_list)
        {
            Debug.Log(i);
        }
    }
}

public class Dictionary_owner
{
    private Dictionary<string, int> m_dict = new Dictionary<string, int>();

    public Dictionary_owner()
    {
        m_dict.Add("fanzhengyong", 1);
        m_dict.Add("chengyan",     2);
    }

    public Dictionary<string, int> GetDictionary()
    {
        return m_dict;
    }

    public void PrintDictionary()
    {
        foreach (KeyValuePair<string, int> kv in m_dict)
        {
            Debug.LogFormat("{0}, {1}", kv.Key, kv.Value);
        }
   }

}

public class DictGo_owner
{
    private Dictionary<string, GameObject> m_dict = new Dictionary<string, GameObject>();

    public bool add(string name, GameObject go)
    {
        if (m_dict.ContainsKey(name))
        {
            return false;
        }
        m_dict.Add(name, go);
        return true;
    }

    public Dictionary<string, GameObject> GetDict()
    {
        return m_dict;
    }

    public GameObject GetGo(string name)
    {
        if (m_dict.ContainsKey(name))
        {
            return m_dict[name];
        }

        return null;
    }
}
public class list_modify : MonoBehaviour
{
    private GameObject m_go3;
	void Start ()
	{
	    List_owner listowner = new List_owner();
        listowner.PrintList();
	    List<int> list = listowner.GetList();
	    list[0] = 100;
	    listowner.PrintList();

	    Dictionary_owner dictowner = new Dictionary_owner();
	    dictowner.PrintDictionary();
	    Dictionary<string, int> dict = dictowner.GetDictionary();
        dict["fanzhengyong"] = 100;
        dictowner.PrintDictionary();

	    DictGo_owner dictGoowner = new DictGo_owner();
	    GameObject go = CreateUIGo();
	    dictGoowner.add("test_1", go);
	    Dictionary<string, GameObject> dictGo = dictGoowner.GetDict();
	    dictGo["test_1"].SetActive(false);
	    GameObject go2 = dictGo["test_1"];
	    m_go3 = dictGoowner.GetGo("test_1");
	    m_go3.SetActive(true);
        
        GameObject.Destroy(m_go3.GetComponent<MessageBoxScript>());
        if (dictGo["test_1"].GetComponent<MessageBoxScript>() != null)
        {
            m_go3.GetComponent<MessageBoxScript>().ShowMessage("现在还没死了，Update后我才死");
	        Debug.Log("remove com failed");
	    }
	    else
	    {
	        Debug.Log("remove com successed");
	    }



	}

    public  GameObject CreateUIGo()
    {
        GameObject UIRootGo = GameObject.FindWithTag("UIRoot");
        if (UIRootGo == null)
        {
            return null;
        }

        //先看下UIROOT下有没有挂，没有就从资源文件夹中创建一个
        GameObject UIMessageBoxGo = null;
        Transform UIMessageBoxtrs = UIRootGo.transform.Find("Panel_mssagebox");
        if (UIMessageBoxtrs == null)
        {
            UIMessageBoxGo = GameObject.Instantiate(Resources.Load("Prefabs/Panel_mssagebox", typeof(GameObject))) as GameObject;
            if (UIMessageBoxGo == null)
            {
                return null;
            }
        }

        //挂到UI根节点下
        RectTransform UIRootTransform = UIRootGo.GetComponent<RectTransform>();
        UIMessageBoxGo.transform.SetParent(UIRootTransform, false);

        //如果没有脚本添加脚本组件
        MessageBoxScript messageBoxScript = UIMessageBoxGo.GetComponent<MessageBoxScript>();
        if (messageBoxScript == null)
        {
            messageBoxScript = UIMessageBoxGo.AddComponent<MessageBoxScript>();
        }

        messageBoxScript.ShowMessage("test_1");
        return UIMessageBoxGo;

    }

    void Update()
    {
        if (m_go3.GetComponent<MessageBoxScript>() == null)
        {
            Debug.Log("update :remove com successed");
        }
        
    }



}
