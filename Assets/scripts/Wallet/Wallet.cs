using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public static Wallet Instance { get; private set; }

    [SerializeField] private int _money;

    public event Action<int> OnMoneyChanged;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public int GetMoney()
    {
        return _money;
    }

    public void TakeMoney(int money)
    {
        _money += money;

        OnMoneyChanged?.Invoke(money);
    }

    public void GiveMoney(int money)
    {
        _money -= money;

        OnMoneyChanged?.Invoke(money);
    }
}
