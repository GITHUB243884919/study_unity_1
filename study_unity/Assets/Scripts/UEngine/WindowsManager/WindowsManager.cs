using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Reflection;

namespace UEngine
{
    public class WindowsManager
    {
        private static WindowsManager m_Instance = null;
        public static WindowsManager Instance()
        {
            if (m_Instance == null)
            {
                m_Instance = new WindowsManager();
            }
            return m_Instance;
        }

        //成员变量
        //画布上创建对象
        private Canvas m_Canvas = null;
        private RectTransform m_CanvasRectTransform = null;

        //窗口事件关联列表
        public Dictionary<string, IWindow> m_mapWindows = new Dictionary<string, IWindow>();
        public void Init()
        {
            //获取画布
            m_Canvas = GameObject.FindWithTag("UIRoot").GetComponent<Canvas>();
            if (m_Canvas != null)
            {
                m_CanvasRectTransform = m_Canvas.gameObject.GetComponent<RectTransform>();
            }

            PreLoadAllWindows();
        }

        /// <summary>
        /// 预加载所有的Window
        /// 因为IOS不能很好支持反射，在这里把所有的IWindow子类硬编码的形式加入到map中
        /// 并执行其PreLoad方法。每个IWindow的子类的PreLoad其实是对消息的注册。这样就完成
        /// 了所有窗口消息的注册
        /// </summary>
        void PreLoadAllWindows()
        {
            //假设 MyWindow 继承 IWindow
            //IWindow myWindow = new MyWindow()
            //m_mapWindows.add("MyWindow", myWindow);
            //myWindow.OnPreLoad()

        }

        public void AddUI(GameObject ui)
        {
            if (m_Canvas == null)
            {
                return;
            }

            ui.transform.SetParent(m_CanvasRectTransform, false);
        }

        public RectTransform getRectTransfrom()
        {
            return m_CanvasRectTransform;
        }

        public float getSizeDeltaX()
        {
            float fResult = 0.0f;
            if (m_CanvasRectTransform)
            {
                fResult = m_CanvasRectTransform.sizeDelta.x;
            }
            return fResult;
        }

        public float getSizeDeltaY()
        {
            float fResult = 0.0f;
            if (m_CanvasRectTransform)
            {
                fResult = m_CanvasRectTransform.sizeDelta.y;
            }
            return fResult;
        }
    }
}

