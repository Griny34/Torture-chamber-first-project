using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MatchView : MonoBehaviour
{
    [Header("Model")]
    [SerializeField] private MatchModel _matchModel;

    [Header("UIPlayer")]
    [SerializeField] private TextMeshProUGUI _playerProgress;
    [SerializeField] private TextMeshProUGUI _playerProgress2;
    [Header("UIEnemy1")]
    [SerializeField] private TextMeshProUGUI _enemyFirstProgress;
    [SerializeField] private TextMeshProUGUI _enemyFirstProgress2;
    [SerializeField] private Enemy _enemyFirst;
    [Header("UIEnemy2")]
    [SerializeField] private TextMeshProUGUI _enemySecondProgress;
    [SerializeField] private TextMeshProUGUI _enemySecondProgress2;
    [SerializeField] private Enemy _enemySecond;

    private void Start()
    {
        Wallet.Instance.OnMoneyChanged += value =>
        {
            UpdateUI(_playerProgress.text, Wallet.Instance.GetMoney());
            UpdateUI(_playerProgress2.text, Wallet.Instance.GetMoney());
        };

        _enemyFirst.OnMoneyChanged += value =>
        {
            UpdateUI(_enemyFirstProgress.text, _enemyFirst.GetMoneyEnemy());
            UpdateUI(_enemyFirstProgress2.text, _enemyFirst.GetMoneyEnemy());
        };

        _enemySecond.OnMoneyChanged += value =>
        {
            UpdateUI(_enemySecondProgress.text, _enemySecond.GetMoneyEnemy());
            UpdateUI(_enemySecondProgress2.text, _enemySecond.GetMoneyEnemy());
        };
    }

    private void UpdateUI(string text, int value)
    {
        text = value.ToString();
    }
}
