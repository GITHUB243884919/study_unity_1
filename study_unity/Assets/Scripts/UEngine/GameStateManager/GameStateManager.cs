using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UEngine
{
    public enum EGameState
    {
        None,       // 无
        Update,     // 更新
        Login,      // 登录
        Main,       // 主城
        Battle,     // 战斗
    }

    class GameStateManager
    {
        private static GameStateManager m_Instance = null;
        public static GameStateManager Instance()
        {
            if (m_Instance == null)
            {
                m_Instance = new GameStateManager();
            }
            return m_Instance;
        }

        private Dictionary<EGameState, GameState> m_DicGameStates = new Dictionary<EGameState, GameState>();
        private GameState m_CurState = null;

        public GameStateManager()
        {

        }

        public bool Init()
        {
            m_DicGameStates.Add(EGameState.Update, new GameStateUpdate());
            m_DicGameStates.Add(EGameState.Login, new GameStateLogin());
            m_DicGameStates.Add(EGameState.Main, new GameStateMain());
            m_DicGameStates.Add(EGameState.Battle, new GameStateBattle());
            return true;
        }

        public void ChangeState(EGameState state)
        {
            if (m_CurState != null && m_CurState.State != state)
            {
                m_CurState.Exit();
            }

            m_CurState = m_DicGameStates[state];
            m_CurState.Enter();
        }

        public void Update()
        {
            if (m_CurState != null)
            {
                m_CurState.Update();
            }
        }


    }
}
