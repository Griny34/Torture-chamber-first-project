using Gameplay.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public static Upgrade Instace { get; private set; }

    [SerializeField] private Wallet _wallet;
    [SerializeField] private int _pretiumUpgradeSpeedPlayer;
    [SerializeField] private int _countPaySpeed;
    [SerializeField] private int _maxPaySpeed;

    [SerializeField] private int _pretiumUpgradeDeskInventory;
    [SerializeField] private int _countPayDesk;
    [SerializeField] private int _maxPayDesk;

    [SerializeField] private int _pretiumUpgradeChairInventory;
    [SerializeField] private int _countPayChair;
    [SerializeField] private int _maxPayChair;

    [SerializeField] private TriggerHandler _ChairArea;
    [SerializeField] private TestSpawnerChair _spawnerChair;
    [SerializeField] private int _pretiumUpgradeChairArea;
    [SerializeField] private int _countPayArea;
    [SerializeField] private int _maxPayArea;

    [SerializeField] private int _pretiumUpgradeMoney;
    [SerializeField] private int _countPayMoney;
    [SerializeField] private int _maxPayMoney;

    public event Action OnBuySpeedPlayer;
    public event Action OnBuyDeskInventory;
    public event Action OnBuyChairInventory;
    public event Action OnBuyMoney;

    private void Awake()
    {
        if(Instace != null)
        {
            Destroy(gameObject);
            return;
        }

        Instace = this;
    }

    public void BuyUpgradeSpeedPlayer()
    {
        if(_wallet.GetMoney() >= _pretiumUpgradeSpeedPlayer && _countPaySpeed < _maxPaySpeed)
        {
            OnBuySpeedPlayer?.Invoke();
            _wallet.GiveMoney(_pretiumUpgradeSpeedPlayer);
            _countPaySpeed++;
        }
        else
        {
            //событие со звуком и покраснением бумажника
        }
    }

    public void BuyUpgrateDeskInventory()
    {
        if (_wallet.GetMoney() >= _pretiumUpgradeSpeedPlayer && _countPayDesk < _maxPayDesk)
        {
            OnBuyDeskInventory?.Invoke();
            _wallet.GiveMoney(_pretiumUpgradeDeskInventory);
            _countPayDesk++;
        }
        else
        {

        }  
    }

    public void BuyUpgrateChairInventory()
    {
        if(_wallet.GetMoney() >= _pretiumUpgradeChairInventory && _countPayChair < _maxPayChair)
        {
            OnBuyChairInventory?.Invoke();
            _wallet.GiveMoney(_pretiumUpgradeChairInventory);
            _countPayChair++;
        }
        else
        {

        }
    }

    public void BuyUpgrateAreaChair()
    {
        if(_wallet.GetMoney() >= _pretiumUpgradeChairArea && _countPayArea < _maxPayArea)
        {
            _ChairArea.gameObject.SetActive(true);
            _spawnerChair.enabled = true;
            _wallet.GiveMoney(_pretiumUpgradeChairArea);
            _countPayArea++;
        }
        else
        {

        }
    }

    public void BuyUpgrateMoney()
    {
        if(_wallet.GetMoney() >= _pretiumUpgradeMoney && _countPayMoney < _maxPayMoney)
        {
            OnBuyMoney?.Invoke();
            _wallet.GiveMoney(_pretiumUpgradeMoney);
            _countPayMoney++;
        }
        else
        {

        }
    }
}
