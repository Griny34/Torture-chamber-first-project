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

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _goalProgress;

    private void Start()
    {
        Wallet.Instance.OnMoneyChanged += value =>
        {
            UpdateUI();
        };
    }

    private void UpdateUI()
    {
        _goalProgress.text = $"{Wallet.Instance.GetMoney()}/{_matchModel.CurrentMatch.Money}";
    }
}
