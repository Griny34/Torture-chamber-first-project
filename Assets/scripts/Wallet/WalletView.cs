using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _money;
    [SerializeField] private TextMeshProUGUI _money2;
    [SerializeField] private TextMeshProUGUI _money3;
    [SerializeField] private TextMeshProUGUI _money4;
    [SerializeField] private Wallet _wallet;

    private void Awake()
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
        _money2.text = _wallet.GetMoney().ToString();
        _money3.text = _wallet.GetMoney().ToString();
        _money4.text = _wallet.GetMoney().ToString();
    }
}
