using Gameplay.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerChair : MonoBehaviour
{
    [SerializeField] private Chair _prefapChair;
    [SerializeField] private Transform _spawnerChair;
    [SerializeField] private float _countDesks;
    [SerializeField] private TriggerHandler _chairConstructionArea;
    [SerializeField] private DeskInventory _deskInventory;
    [SerializeField] private TriggerHandler _chairAria;
    [SerializeField] private ChairInventory _chairInventory;

    private List<Chair> _chairs = new List<Chair>();
    private Item _relevantDesk;
    private Chair _relevantChair;
    private int _count = 0;
    public bool IsOpen { get; private set; } = true;

    private void Start()
    {
        _chairAria.OnEnter += (col) =>
        {
            if (col.GetComponent<MovementPlayer>() == null) return;
            if(_chairInventory.IsFull == true) return;

            if(_chairs.Count >= 0)
            {
                _relevantChair = GetLastItem();
                _chairInventory.AddItem(_relevantChair);
                _chairs.Remove(_relevantChair);
            }
        };

        _chairAria.OnExit += (col) =>
        {
            if (col.GetComponent<MovementPlayer>() == null) return;
        };
    }

    private void CreatChairs()
    {
        Chair chair = Instantiate(_prefapChair, _spawnerChair.transform.position, Quaternion.identity);

        chair.OnStarted += () =>
        {
            _count = 0;
            IsOpen = true;
        };

        _chairs.Add(chair);
    }

    public Chair GetLastItem()
    {
        if (_chairs.Count <= 0)
        {
            return null;
        }

        return _chairs[_chairs.Count - 1];
    }

    public void OutItem()
    {
        if (IsOpen == true && _deskInventory.GetLastItem() != null)
        {
            _relevantDesk = _deskInventory.GetLastItem();
            _deskInventory.RemoveItem(_relevantDesk);
            _relevantDesk.StartMove(transform);

            _relevantDesk.OnFinished += () =>
            {
                _count++;
                Destroy(_relevantDesk.gameObject);

                if (_countDesks <= _count)
                {
                    IsOpen = false;
                    CreatChairs();
                }
            };

            _relevantDesk.OnFinished += OutItem;
        }
    }

    public void StopMoveDesk()
    {
        if (_relevantDesk != null)
        {
            _relevantDesk.OnFinished -= OutItem;
        }
    }
}
