using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UEngine
{
    public class UIPool
    {
        private Dictionary<string, GameObject> gameObjects;

        public bool Init()
        {
            gameObjects = new Dictionary<string, GameObject>();
            return true;
        }

        public bool Add(string _name, GameObject _go)
        {
            bool result = false;
            
            if (
                (_go == null) ||
                (!Common.IsValidString(_name))
            )
            {
                return result;
            }

            if (gameObjects.ContainsKey(_name))
            {
                return result;
            }

            gameObjects.Add(_name, _go);
            result = true;

            return result;
        }

        public bool remove(string _name)
        {
            return false;
        }

        public GameObject Spawn(string _name)
        {
            GameObject retGo = null;
            if (gameObjects.ContainsKey(_name))
            {
                retGo = gameObjects[_name];
                retGo.SetActive(true);
            }
            
            return retGo;
            
        }

        public bool Despawn(string _name)
        {
            bool result  = false;

            GameObject go = null;
            if (gameObjects.ContainsKey(_name))
            {
                go = gameObjects[_name];
                if (go)
                {
                    go.SetActive(false);
                    result = true;
                }
            }

            return result;

        }
    }
}

