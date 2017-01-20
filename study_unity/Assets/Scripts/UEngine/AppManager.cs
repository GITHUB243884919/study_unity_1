using UnityEngine;
using System.Collections;

namespace UEngine
{
    internal class AppManager
    {
        private static AppManager app;
        public static GameManager game;

        public static void Create()
        {
            if (app == null)
            {
                app = new AppManager();
                game = new GameManager();
            }
            else
            {
                Debug.LogError("Duplicate App.");
            }

            game.Init();
        }

        public void Start()
        {

        }

        public void Update()
        {
            game.Update();
            if (Time.frameCount % 50 == 0)
            {
                System.GC.Collect();
            }
        }

        public void FixedUpdate()
        {
            game.FixedUpdate();
        }

        public void LateUpdate()
        {
            game.LateUpdate();
        }

        public void OnGUI()
        {
            game.UpdateGUI();
        }

        public void Destroy()
        {
            Debug.Log("Destroy App.");
            game.Destroy();
            game = null;
            app = null;
        }

        public void Pause(bool pause)
        {
            if (pause)
            {
                Debug.Log("Pause App.");
                //Application.targetFrameRate = 1;
            }
            else
            {
                Debug.Log("Resume App.");
                //Application.targetFrameRate = 40;
            }
            game.Pause(pause);
        }

        public static AppManager Instance
        {
            get
            {
                return app;
            }
        }
    }
}

