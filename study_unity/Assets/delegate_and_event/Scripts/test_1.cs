/// <summary>
/// date ： 2016-02-29
/// delegate 和 event 的基本学习范例
/// 感觉delegate 像c++的函数指针，而event像typedef的函数指针，
/// 而event变量+=像是对函数指针容器里增加函数指针，执行的时候先执行先+=的，也就是先进先出，是个队列
/// 
/// </summary>

using UnityEngine;
using System.Collections;
using test_1_namespace;


namespace test_1_namespace
{
    class Cat
    {
        private string name;

        public Cat(string name)
        {
            this.name = name;
        }

        public delegate void CatShoutEventHandle();

        public event CatShoutEventHandle CatShout;

        public void Shout()
        {
            Debug.Log("我是猫" + name);
            if (CatShout != null)
            {
                CatShout();
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

        public void Run()
        {
            Debug.Log("猫来了 " + name + " 快跑");
        }

    }

}


public class test_1 : MonoBehaviour 
{

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
