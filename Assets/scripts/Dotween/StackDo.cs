using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackDo : MonoBehaviour
{
    [SerializeField] private Transform _pointStartStack;
    [SerializeField] private int _maxCountdesk;
    [SerializeField] private int _countDeskForCreatChair;

    private List<TestDesk> _inventoryDesks = new List<TestDesk>();
    private float _number = 0;
    private int _countGiveDesk;
    private bool _allDesk = true;

    public bool IsFull => _inventoryDesks.Count >= _maxCountdesk;

    private void Start()
    {
        Upgrade.Instace.OnBuyDeskInventory += () =>
        {
            _maxCountdesk++;
        };
    }

    public void AddDesk(TestDesk desk)
    {
        _inventoryDesks.Add(desk);

        desk.transform.DOJump(_pointStartStack.position + new Vector3(0, 0.025f + _number, 0), 1f, 1, 1f).OnComplete(
            () => {               
                desk.transform.SetParent(_pointStartStack.transform, true);
                desk.transform.localPosition = new Vector3(0, 0.025f + _number, 0);
                desk.transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
                _number += 0.2f;
            });
    }

    public void RemoveDesk(TestDesk desk, Transform pointDestroy)
    {
        if (desk == null) return;

        desk.transform.SetParent(null);

        desk.transform.DOJump(pointDestroy.position, 1, 1, 0.8f).OnComplete(
            () =>
            {
                _inventoryDesks.Remove(desk);
                Destroy(desk.gameObject);
                _countGiveDesk++;
                _number -= 0.2f;

                if (_countGiveDesk == _countDeskForCreatChair)
                {
                    _allDesk = false;
                }
            });
    }

    public TestDesk GetLastDesk()
    {
        if( _inventoryDesks.Count <= 0)
        {
            return null;
        }
        
        return _inventoryDesks[_inventoryDesks.Count - 1];
    }

    public void ResetValue()
    {
        _countGiveDesk = 0;
    }

    public bool GetBoolAllDesk()
    {
        return _allDesk;
    }

    public void ChangeBoolAllDesk()
    {
        _allDesk = true;
    }
}
