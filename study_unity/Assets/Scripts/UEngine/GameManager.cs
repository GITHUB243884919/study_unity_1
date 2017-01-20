using UnityEngine;
using System.Collections;

namespace UEngine
{
    internal class GameManager
    {
        public GameManager()
        {
            Debug.Log("Create Game.");
        }

        public void Init()
        {
            Debug.Log("Init Game.");
            GameStateManager.Instance().Init();
            ResourceManager.Instance().Init();
            EventManager.Instance().Init();
            WindowsManager.Instance().Init();
            SceneManager.Instance().Init();
            GameStateManager.Instance().ChangeState(EGameState.Update);

        }

        public void Update()
        {
            //GameStateManager.Instance().Update();
            //EventManager.Instance().processAllEvent();
        }

        public void FixedUpdate()
        {
            //ResourceManager.Instance().FixedUpdate();

            //return;
            //NetManager.Instance().FixedUpdate();
        }

        public void LateUpdate()
        {
            
        }

        public void UpdateGUI()
        {
            
        }

        public void Pause(bool pause)
        {
            if (pause)
            {
                Debug.Log("Pause Game.");
            }
            else
            {
                Debug.Log("Resume Game.");
            }
        }
        public void Destroy()
        {
            Debug.Log("Destroy Game.");
        }
    }
}
