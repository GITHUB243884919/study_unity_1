/// <summary>
/// date ：2016-03-04
/// fanzhengyong
/// messagebox ，比较简陋，主要用于手机打印错误信息
/// </summary>
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace UEngine
{
    public class MessageBoxScript : MonoBehaviour
    {
        void Start ()
        {
                initButtonOK();
        }

        public void ShowMessage (string message)
        {
            GameObject textGo = FindContorl("Text_message");
            if (textGo == null)
            {
                return;
            }

            Text text = textGo.GetComponent<Text>();
            if (text == null)
            {
                return;
            }

            text.text = message;

            transform.SetAsLastSibling();
            gameObject.SetActive(true);
            
        }
        
        void initButtonOK()
        {
            GameObject buttonGo = FindContorl("Button_OK");
            if (buttonGo == null)
            {
                Debug.Log("buttonGo == null");
                return;
            }
            Debug.Log(buttonGo.name);
            Button button = buttonGo.GetComponent<Button>();
            button.onClick.AddListener(OnClickButtonOK);
        }

        GameObject FindContorl(string name)
        {
            Transform transform = gameObject.transform.Find(name);
            if (transform == null)
            {
                return null;
            }
            Debug.Log(transform.name);
            Debug.Log(transform.gameObject.name);
            return transform.gameObject;
        }

        void OnClickButtonOK()
        {
            Debug.Log("!!!!!");
            gameObject.SetActive(false);
        }

    }
}
