/// <summary>
/// date ： 2016-02-29
/// 工具函数
/// </summary>

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UEngine
{

    public class Common
    {
#if UNITY_EDITOR
        /// <summary>
        /// 得到场景中所有的GameObject，包含deactive的
        /// </summary>
        /// <param name="isFindChild">是否包含子GameObject，如果为false就只返回场景中顶层的GameObject</param>
        /// <returns></returns>
        public static GameObject[] GetAllGameObjectInScene(bool isGetChild)
        {
            GameObject[] allGos = (GameObject[]) Resources.FindObjectsOfTypeAll(typeof (GameObject));
            GameObject go = null;
            List<GameObject> resultGos = new List<GameObject>();
            for (int i = 0; i < allGos.Length; i++)
            {
                go = allGos[i];
                if (isGetChild == false)
                {
                    if (go.transform.parent != null)
                    {
                        continue;
                    }
                }

                if (go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave)
                {
                    continue;
                }

                if (Application.isEditor)
                {
                    string sAssetPath = AssetDatabase.GetAssetPath(go.transform.root.gameObject);
                    if (!string.IsNullOrEmpty(sAssetPath))
                    {
                        continue;
                    }
                }

                resultGos.Add(go);
            }
            return resultGos.ToArray();

        }
#endif
        /// <summary>
        /// 得到场景中所有的active的GameObject
        /// </summary>
        /// <param name="isGetChild">是否包含子GameObject，如果为false就只返回场景中顶层的GameObject</param>
        /// <returns></returns>
        public static GameObject[] GetAllActiveGameObjectInScene(bool isGetChild)
        {
            GameObject[] allGos = (GameObject[])Object.FindObjectsOfType(typeof(GameObject));
            GameObject go = null;
            List<GameObject> resultGos = new List<GameObject>();
            for (int i = 0; i < allGos.Length; i++)
            {
                go = allGos[i];
                if (isGetChild == false)
                {
                    if (go.transform.parent != null)
                    {
                        continue;
                    }
                }
                resultGos.Add(go);
            }
            return resultGos.ToArray();
        }
#if UNITY_EDITOR
        /// <summary>
        /// 得到Prefab所在的资源路径，这个函数只有在编辑器模式下，并且没有run才有效。
        /// 只能在Editor目录下被调用才有效
        /// </summary>
        /// <param name="go"></param>
        /// <returns></returns>
        public static string GetPrefabAssetPath(GameObject go)
        {
            string resultPath = null;
            if (PrefabUtility.GetPrefabType(go) == PrefabType.PrefabInstance)
            {
                UnityEngine.Object parentObject = PrefabUtility.GetPrefabParent(go);
                resultPath = AssetDatabase.GetAssetPath(parentObject);
                //Debug.Log(resultPath);
                if (string.IsNullOrEmpty(resultPath))
                {
                    Debug.Log("异常" + go.name + "的路径为空");
                }
            }
            return resultPath;
        }
        //end public static string GetPrefabAssetPath(GameObject go)
#endif
        /// <summary>
        /// 创建assetbundle文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <param name="info"></param>
        /// <param name="length"></param>
        public static void CreateAssetbundleFile(string path, string name, byte[] data)
        {
            //文件流信息
            Stream stream = null;
            try
            {
                FileInfo fileInfo = new FileInfo(path + "/" + name);
                using (stream = fileInfo.Open(FileMode.Create))
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.ToString());
            }
        }

        public static void MessageBox(string message)
        {
            GameObject UIRootGo = GameObject.FindWithTag("UIRoot");
            if (UIRootGo == null)
            {
                return;
            }

            //先看下UIROOT下有没有挂，没有就从资源文件夹中创建一个
            GameObject UIMessageBoxGo = null;
            Transform UIMessageBoxtrs = UIRootGo.transform.Find("Panel_mssagebox");
            if (UIMessageBoxtrs == null)
            {
                UIMessageBoxGo = GameObject.Instantiate(Resources.Load("Prefabs/Panel_mssagebox", typeof(GameObject))) as GameObject;
                if (UIMessageBoxGo == null)
                {
                    return;
                }
            }

            //挂到UI根节点下
            RectTransform UIRootTransform = UIRootGo.GetComponent<RectTransform>();
            UIMessageBoxGo.transform.SetParent(UIRootTransform, false);

            //如果没有脚本添加脚本组件
            MessageBoxScript messageBoxScript = UIMessageBoxGo.GetComponent<MessageBoxScript>();
            if (messageBoxScript == null)
            {
                messageBoxScript = UIMessageBoxGo.AddComponent<MessageBoxScript>();
            }

            messageBoxScript.ShowMessage(message);

        }

        public static void ErrorMessage(string message)
        {
            if (!IsValidString(message)) return;

            StackTrace stackTrace = new StackTrace(new StackFrame(true));
            StackFrame stackFrame = stackTrace.GetFrame(0);
            message += string.Format("\nFile: {0}", stackFrame.GetFileName());
            message += string.Format("\nMethod: {0}", stackFrame.GetMethod());
            message += string.Format("\nLine Number: {0}", stackFrame.GetFileLineNumber());
            message += string.Format("\nColumn Number: {0}", stackFrame.GetFileColumnNumber());
            MessageBox(message);
        }

        public static bool IsValidString(string value)
        {
            if ((value == null) || (value.Length == 0))
                return false;
            return true;
        }

        public static bool StringCompare(string value1, string value2)
        {
            if (!IsValidString(value1) || !IsValidString(value2))
                return false;
            return value1.Equals(value2);
        }

        public static bool String2Int32(string inValue, ref int outValue)
        {
            bool result = false;

            int tempValue = 0;
            if (!IsValidString(inValue))
            {
                return result;
            }

            try
            {
                tempValue = Convert.ToInt32(inValue);
                outValue = tempValue;
                result = true;

            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                result = false;
            }

            return result;
        }

    }
    //end public class Common



}
