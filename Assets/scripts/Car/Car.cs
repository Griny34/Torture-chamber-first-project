using Gameplay.Common;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Car : MonoBehaviour
{
    [Header("General properties")]
    [SerializeField] private int _maxCountChair;
    [SerializeField] private float _speed;

    [Header("Handlers")]
    [SerializeField] private TriggerHandler _carAria;
    [SerializeField] private ChairInventory _chairInventory;

    [SerializeField] private SpawnerMoney _spawnerMoney;
    [SerializeField] private int _countMoney;
 
    private List<Item> _chairs = new List<Item>();
    private Item _relevantChair;
    private Coroutine _corutine;

    public static Car Instance { get; private set;}

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        _carAria.OnEnter += (col) =>
        {
            if (col.GetComponent<MovementPlayer>() == null) return;

            _relevantChair = _chairInventory.GetLastItem();

            if (_relevantChair == null) return;

            _chairInventory.RemoveItem(_relevantChair);
            _relevantChair.StartMove(transform);
            _chairs.Add(_relevantChair);

            if (_chairs.Count == _maxCountChair)
            {
                if(_corutine != null)
                {
                    StopCoroutine(_corutine);
                }

                _corutine = StartCoroutine(MoveCarCoroutine());
            }
        };
    }

    private IEnumerator MoveCarCoroutine()
    {
        //play animation

        yield return new WaitForSeconds(3);

        _spawnerMoney.CreateMoney();
        _chairs.Clear();
        DestroyChair();

        yield return null;

        _corutine = null;
    }

    private void DestroyChair()
    {
        foreach(var chair in _chairs)
        {
            Destroy(chair);
        }
    }
}
