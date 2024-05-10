using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterMoneyOnScene : MonoBehaviour
{
    public static CounterMoneyOnScene Instance { get; private set; }

    private int _volue = 0;

    public event Action OnChangeVolue;

    public void AddVolue()
    {
        _volue++;

        OnChangeVolue?.Invoke();
    }

    public void SubtractVolue()
    {
        _volue--;

        OnChangeVolue?.Invoke();
    }

    public int GetVolue()
    {
        return _volue * Money.Instance.GetMoneyValue();
    }

    public void RestartVolue()
    {
        _volue = 0;
    }
}
