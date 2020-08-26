using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Pump.HiddenObjects
{
    public class SettingUI : Core.MonoSingleton<SettingUI>
    {
        [SerializeField] Button Resumebtn;
        [SerializeField] Button Exitbtn;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void onClickResume()
        {
            GameManager.instance.State = GameManager.GameState.Play;
            Time.timeScale = 1f;
        }

        private void onClickExit()
        {
            Application.Quit();
        }
    }
}
