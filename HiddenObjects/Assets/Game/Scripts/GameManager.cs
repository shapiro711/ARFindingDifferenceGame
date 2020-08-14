using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Pump.Core;

namespace Pump.HiddenObjects
{
    public class GameManager : MonoSingleton<GameManager>
    {
        private GameStatus gameStatus = new GameStatus();
        private UIControl uiControl;


        public GameStatus GameStatusInfo
        {
            get => this.gameStatus;
        }

        #region * GameState Control
        public enum GameState
        {
            Title,
            Play,
            Setting,
            Result,            
            Ranking
        }

        private GameState state;
        public GameState State
        {
            get { return this.state; }
            set
            {
                this.state = value;
                UIControl.Instance.ChangePanel(this.state);


                switch (this.state)
                {
                    case GameState.Title:
                        break;

                    case GameState.Play:
                        break;

                    case GameState.Setting:
                        break;

                    case GameState.Result:
                        break;
 
                    case GameState.Ranking:
                        break;
                }
            }
        }
        #endregion

        #region * Unity Pipeline
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            this.gameStatus.Load();

            this.uiControl = UIControl.Instance;

            this.State = GameState.Title;
        }

        private void OnApplicationPause(bool value)
        {
            if (value)
            {
                this.gameStatus.Save();
            }
        }

        private void OnApplicationQuit()
        {
            this.gameStatus.Save();
        }
        #endregion

        public void ShowAds()
        {

#if UNITY_EDITOR
            this.Replay();

#elif UNITY_ANDROID || UNITY_IOS
#endif
        }

        public void Replay()
        {
            GameManager.Instance.State = GameState.Play;
        }
    }
}