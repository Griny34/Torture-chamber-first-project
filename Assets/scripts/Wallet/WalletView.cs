using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _money;
    [SerializeField] private TextMeshProUGUI _money2;
    [SerializeField] private TextMeshProUGUI _money5;
    [SerializeField] private TextMeshProUGUI _money6;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TextMeshProUGUI _salary;

    private void Awake()
    {
        _wallet.OnMoneyChanged += value =>
        {
            _money.text = _wallet.GetMoney().ToString();
            _money2.text = _wallet.GetMoney().ToString();
        };

        _wallet.OnSalaryChanged += value =>
        {
            _salary.text = _wallet.GetSalary().ToString();
        };

        _salary.text = _wallet.GetSalary().ToString();
        _money.text = _wallet.GetMoney().ToString();
        _money2.text = _wallet.GetMoney().ToString();
    }
}
