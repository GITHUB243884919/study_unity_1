using UnityEngine;
using System.Collections;

namespace UEngine
{
    public class GameState
    {
        public EGameState State { get; set; }

        public GameState()
        {
            State = EGameState.None;
        }

        public virtual void Enter()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void Exit()
        {

        }
    }
}