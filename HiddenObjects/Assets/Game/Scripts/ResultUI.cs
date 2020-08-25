using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pump.Core;

namespace Pump.HiddenObjects
{
    public class ResultUI : Core.MonoSingleton<PlayUI>
    {
        [SerializeField] Button toTiltlebtn;
        [SerializeField] Button ReStartbtn;
        [SerializeField] Button NextStagebtn;
        [SerializeField] Text ClearText;


        private void Start()
        {
            ReStartbtn.gameObject.SetActive(false);
            NextStagebtn.gameObject.SetActive(false);

            if (PlayUI.Instance.isClear == false)
            {
                ReStartbtn.gameObject.SetActive(true);
                ClearText.text = "YOU DIE";
            }

            else
            {
                NextStagebtn.gameObject.SetActive(true);
                ClearText.text = "CLEAR";
            }

        }

        public void OnClickTitle()
        {
            GameManager.instance.State = GameManager.GameState.Title;
        }

        public void OnClickNextStage()
        {

        }

    }
}