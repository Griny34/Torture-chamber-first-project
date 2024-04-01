using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReadyServise : MonoBehaviour
{
    private void Awake()
    {
        GameReady();
    }

    private void GameReady()
    {
        YandexGamesSdk.GameReady();
    }
}
