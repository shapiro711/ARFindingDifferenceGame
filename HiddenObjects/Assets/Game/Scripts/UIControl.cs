using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Pump.HiddenObjects
{
    public class UIControl : Core.MonoSingleton<UIControl>
    {
        private Transform titlePanel;
        private Transform playPanel;
        private Transform resultPanel;
        private Transform settingPanel;
        private Transform rankingPanel;

        [SerializeField] private Text log;

        public string Log { set { this.log.text = value; } }

        #region * Unity Pipeline

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);

            this.titlePanel = this.transform.Find("Title");
            this.playPanel = this.transform.Find("Play");
            this.resultPanel = this.transform.Find("Result");
            this.settingPanel = this.transform.Find("Setting");
            this.rankingPanel = this.transform.Find("Ranking");

            this.log = this.transform.Find("Log").GetComponent<Text>();
        }

        #endregion

        public void ChangePanel(GameManager.GameState gameState)
        {
            this.titlePanel.gameObject.SetActive(false);
            this.playPanel.gameObject.SetActive(false);
            this.resultPanel.gameObject.SetActive(false);
            this.settingPanel.gameObject.SetActive(false);
            this.rankingPanel.gameObject.SetActive(false);

            switch (gameState)
            {
                case GameManager.GameState.Title:
                    this.titlePanel.gameObject.SetActive(true);
                    break;

                case GameManager.GameState.Play:
                    this.playPanel.gameObject.SetActive(true);
                    break;

                case GameManager.GameState.Setting:
                    this.settingPanel.gameObject.SetActive(true);
                    break;

                case GameManager.GameState.Result:
                    this.resultPanel.gameObject.SetActive(true);                    
                    break;

                case GameManager.GameState.Ranking:
                    this.rankingPanel.gameObject.SetActive(true);
                    break;
            }
        }

        #region * UI Event Action

        #endregion
    }
}