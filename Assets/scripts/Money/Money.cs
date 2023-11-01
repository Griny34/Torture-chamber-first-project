using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public static Money Instance { get; private set; }

    [SerializeField] private int _value;
    [SerializeField] private int _upgradeMoney;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        Upgrade.Instace.OnBuyMoney += () =>
        {
            UpgradeMoney();
        };
    }    

    public int GetMoneyValue()
    {
        return _value;
    }

    private void UpgradeMoney()
    {
        _value += _upgradeMoney;
    }
}
