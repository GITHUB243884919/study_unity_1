using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UEngine
{
    class GameStateLogin : GameState
    {
        public GameStateLogin()
        {
            State = EGameState.Login;
        }

        /// <summary>
        /// 打开登陆界面
        /// </summary>
        public override void Enter()
        {
            Debug.Log("enter GameStateLogin.");
            //GameStateManager.Instance().ChangeState(EGameState.Main);
            //EventManager.Instance().pushEvent("GE_CREATE_LOGIN");
            //本应该在登陆成功后在登陆界面进行状态切换的，但由于目前没有登陆所以直接切换到主城
            GameStateManager.Instance().ChangeState(EGameState.Main);
        }

        public override void Update()
        {

        }

        public override void Exit()
        {
            Debug.Log("exit GameStateLogin.");
            //EventManager.Instance().pushEvent("GE_CLOSE_LOGIN");
        }
    }
}
