using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UEngine
{
    public class PoolManager_Unite2015 : MonoBehaviour
    {


        public static PoolManager_Unite2015 Instance()
        {
            if (poolManager == null)
            {
                poolManager = new PoolManager_Unite2015(128);
            }

            return poolManager;
        }

        private static PoolManager_Unite2015 poolManager;
        // 存储动可服用的GameObject。
        //用过一次的
        private List<GameObject> dormantObjects = new List<GameObject>();
        private int Capacity;

        private PoolManager_Unite2015(int size)
        {
            Capacity = size;
        }

        // 在dormantObjects获取与go类型相同的GameObject,如果没有则new一个。
        public GameObject Spawn(GameObject go)
        {
            GameObject temp = null;
            if (dormantObjects.Count > 0)
            {
                foreach (GameObject dob in dormantObjects)
                {
                    if (dob.name == go.name)
                    {
                        // Find an available GameObject
                        temp = dob;
                        dormantObjects.Remove(temp);
                        return temp;
                    }
                }
            }
            // Now Instantiate a new GameObject.
            temp = GameObject.Instantiate(go) as GameObject;

            temp.name = go.name;
            return temp;
        }
        // 将用完的GameObject放入dormantObjects中
        public void Despawn(GameObject go)
        {
            go.transform.parent = PoolManager_Unite2015.Instance().transform;
            go.SetActive(false);
            dormantObjects.Add(go);
            Trim();
        }

        //FIFO 如果dormantObjects大于最大个数则将之前的GameObject都推出来。
        public void Trim()
        {
            while (dormantObjects.Count > Capacity)
            {
                GameObject dob = dormantObjects[0];
                dormantObjects.RemoveAt(0);
                Destroy(dob);
            }
        }


    }

}
