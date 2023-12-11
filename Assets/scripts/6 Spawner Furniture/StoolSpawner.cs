using Gameplay.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StoolSpawner : MonoBehaviour
{
    [SerializeField] private TriggerHandler _triggerHandler;
    [SerializeField] private TriggerHandler _ariaSpawner;
    [SerializeField] private Stool _prefabStool;
    [SerializeField] private Transform _pointSpawner;

    [SerializeField] private StackMaterial _stackMaterial;
    [SerializeField] private StackFurniture _stackFurniture;

    [SerializeField] private int _countBoardsForCreate;

    private List<Stool> _stools = new List<Stool>();
    private Board _boardRelevant;
    private Board _board;
    private Coroutine _coroutine;
    private int _countBoard;
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

        _ariaSpawner.OnEnter += col =>
        {
            if (_stackFurniture.IsFull == true) return;

            GivStool();
        };
    }

    private void CreatStool()
    {
        Stool stool = Instantiate(_prefabStool, _pointSpawner.position, Quaternion.identity);

        _stools.Add(stool);

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
            _stackMaterial.RemoveDesk(_boardRelevant, gameObject.transform);

            _countBoard++;

            yield return new WaitForSeconds(0.5f);

            if (_countBoardsForCreate <= _countBoard)
            {
                CreatStool();
                yield break;
            }
        }
    }

    private Board SearchBoard()
    {      
        foreach(var material in _stackMaterial.GetListMaterial())
        {
            if(material is Board)
            {
                _board = (Board)material;
                return _board;
            }
        }

        return null;
    }

    private void GivStool()
    {
        if (_stools.Count == 0) return;

        _stools[_stools.Count - 1].transform.position = _stackFurniture.GetTransform().position;

        _stools[_stools.Count - 1].gameObject.transform.SetParent(_stackFurniture.transform);//

        _stackFurniture.AddFurnitur(_stools[_stools.Count - 1]);

        _stools.Remove(_stools[_stools.Count - 1]);

        IsOpen = true;

        _countBoard = 0;
    }
}
