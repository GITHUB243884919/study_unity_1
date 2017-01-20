/// <summary>
/// date ： 2016-02-29
/// delegate 和 event 的用EventArgs派生类传递参数的学习范例
/// 看到一种写法在定义delegate变量的时候没有加event关键字，也行
/// </summary>
using System;
using UnityEngine;
using System.Collections;
using test_3_namespace;

namespace test_3_namespace
{
    public class CatShoutEventArgs : EventArgs
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
    }

    class Cat
    {
        private string name;

        public Cat(string name)
        {
            this.name = name;
        }

        public delegate void CatShoutEventHandle(object sender, CatShoutEventArgs args);

        //定义 CatShout没有加event 关键字也可以
        public CatShoutEventHandle CatShout;

        public void Shout()
        {
            Debug.Log("我是猫" + name);
            if (CatShout != null)
            {
                CatShoutEventArgs args = new CatShoutEventArgs();
                args.Name = name;
                CatShout(this, args);
            }

        }
    }

    class Mouse
    {
        private string name;

        public Mouse(string name)
        {
            this.name = name;
        }

        public void Run(object sender, CatShoutEventArgs args)
        {
            Debug.Log("猫 " + args.Name + " 了 " + name + " 快跑");
        }

    }

}

public class test_3 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Mouse mouse1 = new Mouse("Jerry");
        Mouse mouse2 = new Mouse("Jack");

        Cat cat = new Cat("Tom");
        cat.CatShout += new Cat.CatShoutEventHandle(mouse1.Run);
        cat.CatShout += new Cat.CatShoutEventHandle(mouse2.Run);
        cat.Shout();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
