using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UEngine
{
    public enum ESceneType
    {
        None,
        Main,
        Battle,
    }

    class SceneManager
    {
        private static SceneManager m_Instance = null;
        public static SceneManager Instance()
        {
            if (m_Instance == null)
            {
                m_Instance = new SceneManager();
            }
            return m_Instance;
        }

        private Dictionary<ESceneType, Scene> m_DicGameScenes = new Dictionary<ESceneType, Scene>();
        private Scene m_CurScene = null;

        public SceneManager()
        {

        }

        public Scene GetCurScene()
        {
            return m_CurScene;
        }

        public bool Init()
        {
            m_DicGameScenes.Add(ESceneType.Main, new SceneMain());
            m_DicGameScenes.Add(ESceneType.Battle, new SceneBattle());
            return true;
        }

        public void ChangeScene(ESceneType type)
        {
            if (m_CurScene != null && m_CurScene.m_Type != type)
            {
                m_CurScene.Exit();
            }
            Debug.LogFormat("ChangeScene {0}", type);
            m_CurScene = m_DicGameScenes[type];
            m_CurScene.Enter();
        }

        public void Update()
        {
            if (m_CurScene != null)
            {
                m_CurScene.Update();
            }
        }


    }
}
