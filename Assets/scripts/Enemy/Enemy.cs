using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _moneyGrowth;
    [SerializeField] private int _elapsedTime;

    private int _money = 0;
    private float _time = 0;

    private void Update()
    {
        GrowthMoney();
    }

    public int GetMoneyEnemy()
    {
        return _money;
    }

    private void GrowthMoney() 
    {
        _time += Time.deltaTime;

        if(_time == _elapsedTime)
        {
            _time = 0;

            _money += _moneyGrowth;
        }
    }
}
