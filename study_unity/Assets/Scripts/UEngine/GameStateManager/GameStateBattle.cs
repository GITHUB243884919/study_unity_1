using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UEngine
{
    class GameStateBattle : GameState
    {
        public GameStateBattle()
        {
            State = EGameState.Battle;
        }

        public override void Enter()
        {
            Debug.Log("enter GameStateBattle.");
            SceneManager.Instance().ChangeScene(ESceneType.Battle);
        }

        public override void Update()
        {
            //SceneManager.Instance().Update();
        }

        public override void Exit()
        {
            Debug.Log("exit GameStateBattle.");
        }
    }
}
