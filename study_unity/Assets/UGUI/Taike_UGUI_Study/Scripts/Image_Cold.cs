using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Image_Cold : MonoBehaviour
{
    private Button button;
    private Image mask;

    private bool isCold = false;
    private float coldSecond = 1;
    private float spendSecond = 0;
	void Start ()
	{
	    button = gameObject.GetComponent<Button>();
	    button.onClick.AddListener(OnClick);

	    mask = transform.Find("Mask").gameObject.GetComponent<Image>();
	    mask.fillAmount = 0;

        
	}

    void OnClick()
    {
        isCold = true;
        Debug.Log(Time.time);
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if (isCold)
	    {
	        Debug.Log(Time.time);
	        button.enabled = false;
	        spendSecond += Time.deltaTime;
	        mask.fillAmount = (coldSecond - spendSecond) / spendSecond;
	        //Debug.Log(mask.fillAmount);
	        if (spendSecond >= coldSecond)
	        {
                isCold = false;
	            spendSecond = 0;
                button.enabled = true;
	        }

	    }
	
	}
}
