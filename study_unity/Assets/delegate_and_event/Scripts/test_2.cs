/// <summary>
/// date ： 2016-02-29
/// delegate 和 event 的用EventArgs派生类传递参数的学习范例
/// 这里参数类型不从EventArgs继承，也能正常运行，但查了一些资料说的不是很清楚，但还是加上为好
/// </summary>
using System;
using UnityEngine;
using System.Collections;
using test_2_namespace;

namespace test_2_namespace
{
    //这行代码实际上用下面一行代替也可以
    //public class CatShoutEventArgs 
    //查了资料有的说是为了规范写法，有的说是net 4.5去掉了，无论如何还是加上
    public class CatShoutEventArgs  :  EventArgs
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

        public event CatShoutEventHandle CatShout;

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

public class test_2 : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        Mouse mouse1 = new Mouse("Jerry");
        Mouse mouse2 = new Mouse("Jack");

        Cat cat = new Cat("Tom");
        cat.CatShout += new Cat.CatShoutEventHandle(mouse1.Run);
        cat.CatShout += new Cat.CatShoutEventHandle(mouse2.Run);
        cat.Shout();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
