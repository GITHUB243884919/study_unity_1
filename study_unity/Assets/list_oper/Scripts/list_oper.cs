using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UEngine;

public class list_oper : MonoBehaviour 
{

	// Use this for initialization
	void Start ()
	{
	    string a = "ABC";
	    string b = null;
	    Debug.Log(Common.StringCompare(a, b));
        Debug.Log(Common.StringCompare(b, a));
        string c = null;
        Debug.Log(Common.IsValidString(c));
        
	    List<int> list = new List<int>();

	    for (int i = 0; i < 10; i++)
	    {
	        list.Add(i);
	    }
	    foreach (int i in list)
	    {
	        Debug.Log(i);
	    }

	    int removeCount = 3;
        for (int i = list.Count - 1; i >= 0 && removeCount>0; i--)
        {
            
            list.RemoveAt(i);
            removeCount--;
        }
        foreach (int i in list)
        {
            
            Debug.Log(i);
        }

	    for (int i = list.Count - 1; i >= 0; i--)
	    {
	        list.RemoveAt(i);
	    }
        foreach (int i in list)
        {
            Debug.Log(i);
        }


	}
	

}
