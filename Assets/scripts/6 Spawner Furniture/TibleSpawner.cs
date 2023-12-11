using Gameplay.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TibleSpawner : MonoBehaviour
{
    [SerializeField] private TriggerHandler _triggerHandler;
    [SerializeField] private TriggerHandler _ariaSpavner;
    [SerializeField] private Table _prefabBedside;
    [SerializeField] private Transform _pointSpawner;

    [SerializeField] private StackMaterial _stackMaterial;
    [SerializeField] private StackFurniture _stackFurniture;

    [SerializeField] private int _countBoardsForCreate;
    [SerializeField] private int _countDoubleBedsideForCreate;

    private List<Table> _bedsideTables = new List<Table>();

    private Board _boardRelevant;
    private Board _board;
    private DoubleBedsideTable _bedsideTableRelevant;
    private DoubleBedsideTable _bedsideTable;
    private Coroutine _coroutine;
    private int _countBoard = 0;
    private int _countDoubleBedside = 0;
    private bool IsOpen = true;

    public event Action OnStartEffect;

    private void Start()
    {
        _triggerHandler.OnEnter += col =>
        {
            if (col.GetComponent<JoystickPlayer>() == null) return;

            if (IsOpen == false) return;

            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(AcceptMaterial());
        };

        _triggerHandler.OnExit += col =>
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
        };

        _ariaSpavner.OnEnter += col =>
        {
            if (_stackFurniture.IsFull == true) return;
            Debug.Log("1111");
            GivBedside();
        };
    }

    private void CreatStool()
    {
        Table table = Instantiate(_prefabBedside, _pointSpawner.position, Quaternion.identity);

        _bedsideTables.Add(table);

        IsOpen = false;

        OnStartEffect?.Invoke();
    }

    private IEnumerator AcceptFurniture()
    {
        while (true)
        {
            _bedsideTableRelevant = SearchDoubleBedside();

            Debug.Log(_boardRelevant);

            if (_bedsideTableRelevant == null)
            {
                //StopCoroutine(_coroutine);
                yield break;
            }

            _stackFurniture.RemoveFurniture(_bedsideTableRelevant, gameObject.transform);

            _countDoubleBedside++;

            yield return new WaitForSeconds(0.5f);

            if (_countBoardsForCreate <= _countBoard && _countDoubleBedsideForCreate <= _countDoubleBedside)
            {
                CreatStool();
                yield break;
            }
        }
    }


    private IEnumerator AcceptMaterial()
    {
        while (true)
        {
            _boardRelevant = SearchBoard();

            if (_boardRelevant == null)
            {
                //StopCoroutine(_coroutine);
                yield return StartCoroutine(AcceptFurniture());
                yield break;
            }

            _stackMaterial.RemoveDesk(_boardRelevant, gameObject.transform);

            _countBoard++;

            yield return new WaitForSeconds(0.5f);

            if (_countBoardsForCreate <= _countBoard)
            {
                //CreatStool();
                yield return StartCoroutine(AcceptFurniture());
                yield break;
            }
        }
    }


    private Board SearchBoard()
    {
        foreach (var materiale in _stackMaterial.GetListMaterial())
        {
            if (materiale is Board)
            {
                _board = (Board)materiale;
                return _board;
            }
        }

        return null;
    }

    private DoubleBedsideTable SearchDoubleBedside()
    {
        foreach (var furniture in _stackFurniture.GetListStack())
        {
            if (furniture is DoubleBedsideTable)
            {
                _bedsideTable = (DoubleBedsideTable)furniture;
                return _bedsideTable;
            }
        }

        return null;
    }

    private void GivBedside()
    {
        if (_bedsideTables.Count == 0) return;
        Debug.Log(_bedsideTables[_bedsideTables.Count - 1]);
        _bedsideTables[_bedsideTables.Count - 1].transform.position = _stackFurniture.GetTransform().position;

        _bedsideTables[_bedsideTables.Count - 1].gameObject.transform.SetParent(_stackFurniture.transform);//

        _stackFurniture.AddFurnitur(_bedsideTables[_bedsideTables.Count - 1]);

        _bedsideTables.Remove(_bedsideTables[_bedsideTables.Count - 1]);

        IsOpen = true;

        _countBoard = 0;
    }
}
