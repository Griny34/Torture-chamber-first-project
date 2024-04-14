using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardService : MonoBehaviour
{
    public void ShowRewardAds(Action onCloseCallBack = null)
    {
        if (Agava.WebUtility.WebApplication.IsRunningOnWebGL == false)
        {
            onCloseCallBack?.Invoke();
            return;
        }


        if (Agava.WebUtility.AdBlock.Enabled == true)
        {
            onCloseCallBack?.Invoke();
            return;
        }


        Agava.YandexGames.VideoAd.Show(OnOpenColbek, () =>
        {
            OnCloseColbek();
            onCloseCallBack?.Invoke();
        });
    }

    private void OnOpenColbek()
    {
        Time.timeScale = 0;
        AudioListener.volume = 0f;
    }

    private void OnCloseColbek()
    {
        Time.timeScale = 1;
        AudioListener.volume = 1f;
    }
}
