using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
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

    }

    private void onClickExit()
    {
        Application.Quit();
    }
}
