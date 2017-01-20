/// <summary>
/// date：2016-03-10
/// prefab的缓存池。
/// 说明
/// 1、Init的时候需要把从Assetbundle或者Resource中读出的GameObject,但没有instance存到这里，
///    本类不包含这部分操作，需要在外部完成后调用Init方法。本类存储了一个冗余的变量name，考
///    虑资源路径的问题，这里存储的是包含路径的名字。
/// 2、Spawn/Despawn分别对应了分配和回收一个对象。外部要保证成对使用。
/// 3、Destroy方法只是把一个内部的标志位设置成true，Update方法才是真正的删除。因为考虑到移动
///    设备的性能的问题，每次只删除限定删除个数，因此Update方法要直接或者间接放到程序主循环的
///    Update中，并要带入删除个数。Destory方法也会递减这个参数并ref的形式带出，以供在外部循环
///    中确定是否需要调用
/// 4、UI界面的缓存不要使用这个类
/// </summary>
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UEngine
{
    public class SinglePrefabPool
    {
        private string name;
        private GameObject go;
        private bool isDestory;
        private List<GameObject> activeGameObjects;
        private List<GameObject> deactiveGameObjects;

        public bool Init(string _name, GameObject _go)
        {
            if (
                (_name == null) || (_name.Length == 0) || (_go == null)
                )
            {
                return false;
            }

            go = _go;
            name = _name;
            isDestory = false;
            activeGameObjects = new List<GameObject>();
            deactiveGameObjects = new List<GameObject>();

            return true;
        }

        public GameObject Spawn(string _name, GameObject _owner, Vector3 _position, Vector3 _scale, Quaternion _rotate)
        {
            GameObject retGo        = null;
            bool       isInstance   = false;

            if (!Common.StringCompare(name, _name))
            {
                return retGo;
            }

            if (deactiveGameObjects.Count == 0)
            {
                retGo = GameObject.Instantiate(go) as GameObject;
                isInstance = true;
            }
            else
            {
                retGo = deactiveGameObjects[deactiveGameObjects.Count - 1];
            }

            if (_owner)
            {
                retGo.transform.parent = _owner.transform;
            }
            
            retGo.transform.localPosition = _position;
            retGo.transform.localScale = _scale;
            retGo.transform.localRotation = _rotate;
            activeGameObjects.Add(retGo);

            if (!isInstance)
            {
                retGo.SetActive(true);
                deactiveGameObjects.RemoveAt(deactiveGameObjects.Count - 1);
            }

            return retGo;
        }

        public bool Despawn(string _name, GameObject _go)
        {
            bool retCode = false;

            if (
                (!Common.IsValidString(_name)) || (_go == null)
                )
            {
                return false;
            }

            _go.SetActive(false);
            retCode = activeGameObjects.Remove(go);
            if (!retCode)
            {
                return false;
            }

            deactiveGameObjects.Add(_go);

            return true;

        }

        public void Destroy()
        {
            isDestory = true;
        }

        public void Update(ref int _maxPreDestoryCount)
        {
            if (
                (!isDestory) ||
                (_maxPreDestoryCount <= 0)            
            )
            {
                return;
            }
                

            for (int i = deactiveGameObjects.Count - 1; (i > 0) && (_maxPreDestoryCount > 0); i--)
            {
                deactiveGameObjects.RemoveAt(i);
                GameObject.Destroy(deactiveGameObjects[i]);
                _maxPreDestoryCount--;
            }

            for (int i = activeGameObjects.Count - 1; (i > 0) && (_maxPreDestoryCount > 0); i--)
            {
                activeGameObjects.RemoveAt(i);
                GameObject.Destroy(activeGameObjects[i]);
                _maxPreDestoryCount--;
            }

        }
    }

}
