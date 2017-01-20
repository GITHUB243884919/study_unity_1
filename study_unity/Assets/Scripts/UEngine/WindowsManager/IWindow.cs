using UnityEngine;
using System.Collections;

namespace UEngine
{
    public interface IWindow
    {
        //函数
        void OnPreLoad(); //注册事件
        void OnCreate(); //创建窗口
        void OnClose(); //关闭窗口

        //事件函数
        void OnWinEvent(object sender, SHEventArgs eArgs); //事件函数
    }
}

