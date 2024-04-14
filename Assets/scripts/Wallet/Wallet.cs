using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public static Wallet Instance { get; private set; }

    [SerializeField] private int _money;

    private int _salary = 0;

    public event Action<int> OnMoneyChanged;
    public event Action<int> OnSalaryChanged;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        LoadMoney();
    }

    public int GetSalary()
    {
        return _salary;
    }

    public void TakeSalary(int money)
    {
        _salary += money;

        OnSalaryChanged?.Invoke(money);
    }

    public void RestartSalary()
    {
        _salary = 0;

        OnSalaryChanged?.Invoke(0);
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

    public void SaveMoney()
    {
        PlayerPrefs.SetInt("Money", _money);
    }

    public void LoadMoney()
    {
        if (PlayerPrefs.HasKey("Money") == false)
            return;

        int money = PlayerPrefs.GetInt("Money");

        _money = money;

        OnMoneyChanged?.Invoke(money);
    }

    private void UpdateMoney()
    {
        
    }
}
