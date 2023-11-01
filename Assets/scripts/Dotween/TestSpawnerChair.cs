using Gameplay.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawnerChair : MonoBehaviour
{
    [SerializeField] private Chair _prefapChair;
    [SerializeField] private Transform _spawnerChair;
    [SerializeField] private float _countDesks;
    [SerializeField] private TriggerHandler _chairConstructionArea;
    [SerializeField] private StackDo _deskStack;
    [SerializeField] private TriggerHandler _chairAria;
    [SerializeField] private ChairInventory _chairInventory;

    private List<Chair> _chairs = new List<Chair>();
    private TestDesk _relevantDesk;
    private Chair _relevantChair;
    private Coroutine _coroutine;
    public bool IsOpen { get; private set; } = true;

    private void Start()
    {
        _chairAria.OnEnter += (col) =>
        {
            if (col.GetComponent<MovementPlayer>() == null) return;
            if (_chairInventory.IsFull == true) return;

            if (_chairs.Count >= 0)
            {
                _relevantChair = GetLastItem();
                if (_relevantChair == null) return;
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

        _deskStack.ChangeBoolAllDesk();
        _deskStack.ResetValue();

        chair.OnStarted += () =>
        {
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
        
        if (IsOpen == true && _deskStack.GetLastDesk() != null)
        {
            if (enabled == false) return;

            if(_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(GiveAwayDesk());
        }
    }

    private IEnumerator GiveAwayDesk()
    {       
        while (IsOpen == true && _deskStack.GetLastDesk() != null && _deskStack.GetBoolAllDesk() != false)
        {                       
            _relevantDesk = _deskStack.GetLastDesk();
            _deskStack.RemoveDesk(_relevantDesk, gameObject.transform);
                        
            yield return new WaitForSeconds(1f);
        }

        if (_deskStack.GetBoolAllDesk() == false)
        {
            IsOpen = false;
            CreatChairs();
        }
    }
}
