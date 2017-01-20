using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Panel_Send_With_Image : MonoBehaviour 
{

	// Use this for initialization
	void Start ()
	{
	    Image image = transform.Find("Image").gameObject.GetComponent<Image>();
        //image.overrideSprite = Resources.Load("test", typeof(Sprite)) as Sprite;
        image.sprite = Resources.Load("test", typeof(Sprite)) as Sprite;

	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
