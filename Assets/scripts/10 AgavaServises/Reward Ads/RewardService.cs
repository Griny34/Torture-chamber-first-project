using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardService : MonoBehaviour
{
    public void ShowRewardAds()
    {
        if (Agava.WebUtility.WebApplication.IsRunningOnWebGL == false)
        {
            
            return;
        }


        if (Agava.WebUtility.AdBlock.Enabled == true)
        {
           
            return;
        }


        Agava.YandexGames.VideoAd.Show(OnOpenColbek, AddMoney, OnCloseColbek);
    }

    private void OnOpenColbek()
    {
        Time.timeScale = 0;
        AudioListener.volume = 0f;
    }

    private void AddMoney()
    {

    }
    private void OnCloseColbek()
    {
        Time.timeScale = 1;
        AudioListener.volume = 1f;
    }
}
