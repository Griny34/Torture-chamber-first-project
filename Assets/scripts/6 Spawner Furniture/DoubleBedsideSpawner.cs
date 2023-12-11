using Gameplay.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBedsideSpawner : MonoBehaviour
{
    [SerializeField] private TriggerHandler _triggerHandler;
    [SerializeField] private TriggerHandler _ariaSpavner;
    [SerializeField] private DoubleBedsideTable _prefabBedside;
    [SerializeField] private Transform _pointSpawner;

    [SerializeField] private StackMaterial _stackMaterial;
    [SerializeField] private StackFurniture _stackFurniture;

    [SerializeField] private int _countBoardsForCreate;

    private List<DoubleBedsideTable> _bedsideTables = new List<DoubleBedsideTable>();

    private BedsideTable _boardRelevant;
    private BedsideTable _board;
    private Coroutine _coroutine;
    private int _countBoard = 0;
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

            GivBedside();
        };
    }

    private void CreatStool()
    {
        DoubleBedsideTable bedsideTables = Instantiate(_prefabBedside, _pointSpawner.position, Quaternion.identity);

        _bedsideTables.Add(bedsideTables);

        IsOpen = false;

        OnStartEffect?.Invoke();
    }

    private IEnumerator AcceptMaterial()
    {
        while (true)
        {
            _boardRelevant = SearchBoard();

            if (_boardRelevant == null)
            {
                //StopCoroutine(_coroutine);
                yield break;
            }

            _stackFurniture.RemoveFurniture(_boardRelevant, gameObject.transform);
           
            _countBoard++;

            yield return new WaitForSeconds(0.5f);

            if (_countBoardsForCreate <= _countBoard)
            {
                CreatStool();
                yield break;
            }
        }
    }

    private BedsideTable SearchBoard()
    {
        foreach (var furniture in _stackFurniture.GetListStack())
        {
            if (furniture is BedsideTable)
            {
                _board = (BedsideTable)furniture;
                return _board;
            }
        }

        return null;
    }

    private void GivBedside()
    {
        if (_bedsideTables.Count == 0) return;

        _bedsideTables[_bedsideTables.Count - 1].transform.position = _stackFurniture.GetTransform().position;

        _bedsideTables[_bedsideTables.Count - 1].gameObject.transform.SetParent(_stackFurniture.transform);//

        _stackFurniture.AddFurnitur(_bedsideTables[_bedsideTables.Count - 1]);

        _bedsideTables.Remove(_bedsideTables[_bedsideTables.Count - 1]);

        IsOpen = true;

        _countBoard = 0;
    }
}
