using UnityEngine;
using System;
using System.Collections;

namespace UEngine
{
    public class Main : MonoBehaviour
    {
        public static Main instance = null;

        private void Awake()
        {
            try
            {
                Application.targetFrameRate = 60;
                instance = this;
                UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
                AppManager.Create();
            }
            catch (Exception exception)
            {
                Debug.LogWarning("App awake exception: " + exception.Message + " " + exception.StackTrace);
            }
        }

        private void Start()
        {
            try
            {
                if (AppManager.Instance != null)
                {
                    AppManager.Instance.Start();
                }
                else
                {
                    Debug.LogError("App instance is null");
                }
            }
            catch (Exception exception)
            {
                Debug.LogWarning("App start exception: " + exception.Message + " " + exception.StackTrace);
            }
        }

        private void Update()
        {
            try
            {
                if (AppManager.Instance != null)
                {
                    AppManager.Instance.Update();
                }
                else
                {
                    Debug.LogError("App instance is null");
                }
            }
            catch (Exception exception)
            {
                Debug.LogWarning("App update exception: " + exception.Message + " " + exception.StackTrace);
            }
        }

        private void FixedUpdate()
        {
            try
            {
                if (AppManager.Instance != null)
                {
                    AppManager.Instance.FixedUpdate();
                }
                else
                {
                    Debug.LogError("App instance is null");
                }
            }
            catch (Exception exception)
            {
                Debug.LogWarning("App fixed update exception: " + exception.Message + " " + exception.StackTrace);
            }
        }

        private void LateUpdate()
        {
            try
            {
                if (AppManager.Instance != null)
                {
                    AppManager.Instance.LateUpdate();
                }
                else
                {
                    Debug.LogError("App instance is null");
                }
            }
            catch (Exception exception)
            {
                Debug.LogWarning("App lateupdate exception: " + exception.Message + " " + exception.StackTrace);
            }
        }

        private void OnGUI()
        {
            try
            {
                if (AppManager.Instance != null)
                {
                    AppManager.Instance.OnGUI();
                }
                else
                {
                    Debug.LogError("App instance is null");
                }
            }
            catch (Exception exception)
            {
                Debug.LogWarning("App ongui exception: " + exception.Message + " " + exception.StackTrace);
            }
        }

        private void OnDestroy()
        {
            try
            {
                if (AppManager.Instance != null)
                {
                    AppManager.Instance.Destroy();
                }
                else
                {
                    Debug.LogError("App instance is null");
                }
            }
            catch (Exception exception)
            {
                Debug.LogWarning("App destroy exception: " + exception.Message + " " + exception.StackTrace);
            }
        }

        private void OnApplicationPause(bool flag)
        {
            try
            {
                if (AppManager.Instance != null)
                {
                    AppManager.Instance.Pause(flag);
                }
            }
            catch (Exception exception)
            {
                Debug.LogWarning("App pause exception: " + exception.Message + " " + exception.StackTrace);
            }
        }

        private void OnApplicationQuit()
        {
            try
            {
                Debug.Log("OnApplicationQuit");
            }
            catch (Exception exception)
            {
                Debug.LogWarning("App quit exception: " + exception.Message + " " + exception.StackTrace);
            }
        }
    }
 
}
