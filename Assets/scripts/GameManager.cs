using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Timer _gamerTimer;

    public event Action OnOpenEndGame;

    public void Start()
    {
        _gamerTimer.OnDone += () =>
        {
            GameOver();
        };
    }

    private void GameOver()
    {
        Debug.Log("Game over");
    }
}
