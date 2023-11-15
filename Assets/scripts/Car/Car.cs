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
    [SerializeField] private Transform _positionShop;

    [Header("Handlers")]
    [SerializeField] private TriggerHandler _carAria;
    [SerializeField] private ChairInventory _chairInventory;

    [SerializeField] private SpawnerMoney _spawnerMoney;
    [SerializeField] private int _countMoney;
 
    private List<Item> _chairs = new List<Item>();
    private Item _relevantChair;
    private Coroutine _corutine;
    private Coroutine _corutineChair;
    private Vector3 _startPosition;
    private int _countChair;

    public static Car Instance { get; private set;}

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        _startPosition = transform.position;
    }

    private void Start()
    {
        _carAria.OnEnter += (col) =>
        {
            if (col.GetComponent<JoystickPlayer>() == null) return;

            if(_corutineChair != null)
            {
                StopCoroutine(_corutineChair);
            }

            _corutineChair = StartCoroutine(MoveChair());           
        };

        _carAria.OnExit += (col) =>
        {
            if(_chairs.Count == 0) return;

            if (_corutine != null)
            {
                StopCoroutine(_corutine);
            }

            _corutine = StartCoroutine(MoveCarCoroutine());            
        };
    }

    private IEnumerator MoveChair()
    {
        while (_chairInventory.GetListChair().Count != 0)
        {
            _relevantChair = _chairInventory.GetLastItem();

            //if (_relevantChair == null) return;
            _chairInventory.RemoveItem(_relevantChair);
            _relevantChair.StartMove(transform);
            _chairs.Add(_relevantChair);

            yield return new WaitForSeconds(1f);

            _countChair++;

            yield return null;
        }
        
    }

    private IEnumerator MoveCarCoroutine()
    {
        yield return new WaitForSeconds(0.6f);
        DestroyChair();
        _chairs.Clear();

        while (transform.position != _positionShop.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, _positionShop.position, _speed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(1);

        while (transform.position != _startPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _startPosition, _speed * Time.deltaTime);
            yield return null;
        }

        for(int i = 0; i < _countChair; i++)
        {
            _spawnerMoney.CreateMoney();
        }

        _countChair = 0;
    }

    private void DestroyChair()
    {
        foreach(var chair in _chairs)
        {
            Destroy(chair.gameObject);
        }
    }
}
