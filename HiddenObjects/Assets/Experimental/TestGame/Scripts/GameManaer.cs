using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManaer : MonoBehaviour
{
    [SerializeField] private Slider Timer;
    [SerializeField] private Image Heart1;
    [SerializeField] private Image Heart2;
    [SerializeField] private Image Heart3;


    private void Update()
    {
        if (Timer.value > 0.0f)
        {
            Timer.value -= Time.deltaTime;
        }
    }


}
