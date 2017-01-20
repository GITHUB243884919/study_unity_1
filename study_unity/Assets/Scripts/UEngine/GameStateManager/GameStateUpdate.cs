using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UEngine
{
    class GameStateUpdate : GameState
    {
        public GameStateUpdate()
        {
            State = EGameState.Update;
        }

        /// <summary>
        /// 启动更新画面,调用ResourceManager的更新逻辑,完成后切换到登陆
        /// </summary>
        public override void Enter()
        {
            Debug.Log("enter GameStateUpdate.");


            GameStateManager.Instance().ChangeState(EGameState.Login);
        }

        public override void Update()
        {

        }

        public override void Exit()
        {
            Debug.Log("exit GameStateUpdate.");
        }
    }
}
