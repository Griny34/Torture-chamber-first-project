using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private TextMeshProUGUI _timerText;

    private void Start()
    {
        //_timer.OnStarted += UpdateUI;
        _timer.OnTick += seconds =>
        {
            UpdateUI(seconds);
        };
    }

    private void UpdateUI(int seconds)
    {
        _timerText.text = ParseTime(seconds);
    }

    private string ParseTime(int seconds)
    {
        string number = "";
        int min = seconds / 60;
        int sec = seconds % 60;
       
        if (min < 10)
        {
            number += "0";
        }
        number += min + ":";

        if (sec < 10)
        {
            number += "0";
        }
        number += sec;

        return number ;
    }
}
