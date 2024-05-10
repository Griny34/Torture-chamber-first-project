using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovmentArmchair : Improvement
{
    [SerializeField] private Order _order;
    [SerializeField] private ImprovmentMateriale _improvement;
    [SerializeField] private string _keyPrefsCount;
    [SerializeField] private string _keyPrefsBool;

    private bool _isOpen => PlayerPrefs.GetInt(_keyPrefsBool) != 0;

    private void Start()
    {
        if (_isOpen)
        {
            OpenSpawner();
            return;
        }

        LoadValueCounter();
    }

    public void SaveValueCounter()
    {
        PlayerPrefs.SetInt(_keyPrefsCount, GetValueCounter());

        if (GetBoolIsOpen() == false)
        {
            PlayerPrefs.SetInt(_keyPrefsBool, 1);
        }
    }

    protected override void Change()
    {
        if(_improvement.GetBoolIsOpen() == false)
        {
            _order.OpenAccess();
        }
    }

    private void LoadValueCounter()
    {
        ChangeValueCounter(PlayerPrefs.GetInt(_keyPrefsCount));
    }
}
