using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UEngine
{
    class GameStateMain : GameState
    {
        public GameStateMain()
        {
            State = EGameState.Main;
        }

        /// <summary>
        /// 进入主城，进行场景切换
        /// </summary>
        public override void Enter()
        {
            Debug.Log("enter GameStateMain.");
            //本该进行主城的场景切换，因为当前没有主城，直接切换状态到战斗
            GameStateManager.Instance().ChangeState(EGameState.Battle);
        }

        public override void Update()
        {
            //SceneManager.Instance().Update();
        }

        public override void Exit()
        {
            Debug.Log("exit GameStateMain.");
        }
    }
}
