using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace UEngine
{
    //事件参数
    public class SHEventArgs : System.EventArgs
    {
        public string m_szEventName;
        public int m_nParam;
        public float m_fParam;
    }

    //定义delegate对象
    public delegate void EventHandler(object sender, SHEventArgs eArgs);


    public class EVENT_DEFINE
    {
        public EventHandler m_EventHandler;
        public bool m_DelayProcess;
    }

    public class EVENT
    {
        public SHEventArgs m_eArgs;
        public EVENT_DEFINE m_pEventDef;
    }

    public class EventManager
    {
        private static EventManager m_Instance = null;
        public static EventManager Instance()
        {
            if (m_Instance == null)
            {
                m_Instance = new EventManager();
            }
            return m_Instance;
        }
        //定义成员变量
        private Dictionary<string, EVENT_DEFINE> m_mapEvent = new Dictionary<string, EVENT_DEFINE>();
        private List<EVENT> m_queueEvent = new List<EVENT>();


        //初始化
        public void Init()
        {

        }

        //注册函数
        public void registerEventHandler(string eventName, EventHandler eventHandler, bool isDelay = true)
        {
            //m_mapEvent[eventName].m_EventHandler += eventHandler;
            if (m_mapEvent.ContainsKey(eventName))
            {
                m_mapEvent[eventName].m_EventHandler += eventHandler;
            }
            else
            {
                EVENT_DEFINE eventDefine = new EVENT_DEFINE();
                eventDefine.m_EventHandler = eventHandler;
                eventDefine.m_DelayProcess = isDelay;
                m_mapEvent.Add(eventName, eventDefine);
            }

        }

        //取消注册
        public void unregisterEventHandler(string eventName, EventHandler eventHandler)
        {
            if (m_mapEvent.ContainsKey(eventName))
            {
                m_mapEvent[eventName].m_EventHandler -= eventHandler;
               
            }
        }

        //解析事件
        public void processAllEvent()
        {
            if (m_queueEvent.Count > 0)
            {
                foreach (EVENT e in m_queueEvent)
                {
                    _processEvent(e);
                }
                m_queueEvent.Clear();
            }
        }

        //发送事件
        public void pushEvent(string eventName)
        {
            SHEventArgs args = new SHEventArgs();
            args.m_szEventName = eventName;

            _pushEvent(args);
        }

        public void pushEvent(string eventName, float val)
        {
            SHEventArgs args = new SHEventArgs();
            args.m_szEventName = eventName;
            args.m_fParam = val;

            _pushEvent(args);
        }

        public void pushEvent(string eventName, int val)
        {
            SHEventArgs args = new SHEventArgs();
            args.m_szEventName = eventName;
            args.m_nParam = val;

            _pushEvent(args);
        }

        private void _pushEvent(SHEventArgs eArgs)
        {
            if (m_mapEvent.ContainsKey(eArgs.m_szEventName))
            {
                EVENT tevent = new EVENT();
                tevent.m_pEventDef = m_mapEvent[eArgs.m_szEventName];
                tevent.m_eArgs = eArgs;
                _pushEvent(tevent);
            }
        }

        //发送事件
        void _pushEvent(EVENT shEvent)
        {
            if (shEvent.m_pEventDef != null)
            {
                if (shEvent.m_pEventDef.m_DelayProcess)
                {
                    m_queueEvent.Add(shEvent);
                }
                else
                {
                    _processEvent(shEvent);
                }
            }
        }

        //解析事件
        void _processEvent(EVENT eventHandler)
        {
            EVENT_DEFINE eventDef = eventHandler.m_pEventDef;
            if (eventDef != null && eventDef.m_EventHandler != null)
            {
                eventDef.m_EventHandler(this, eventHandler.m_eArgs);
            }
        }

        void Awake()
        {

        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // processAllEvent();
        }


    }
}

