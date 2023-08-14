using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _money;
    [SerializeField] private Wallet _wallet;

    private void Start()
    {
        _wallet.OnMoneyChanged += value =>
        {
            UpdateUI();
        };


        UpdateUI();
    }

    private void UpdateUI()
    {
        _money.text = _wallet.GetMoney().ToString();
    }
}
