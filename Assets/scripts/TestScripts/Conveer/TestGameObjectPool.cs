using Gameplay.Common;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TestGameObjectPool : MonoBehaviour
{
    [SerializeField] private TriggerHandler _playerTrigger;
    [SerializeField] private MovementPlayer _player;
    [SerializeField] private StackDo _stack;

    [SerializeField] private Transform _contaner;
    [SerializeField] private int _capasity;

    private List<TestDesk> _pool = new List<TestDesk>();
    private TestDesk _relevantDesk;
    private TestDesk _deskPrefab;

    private void Start()
    {
        _playerTrigger.OnEnter += col =>
        {
            if (col.GetComponent<MovementPlayer>() == null) return;

            OutDesk();
        };

        _playerTrigger.OnExit += col =>
        {
            if (col.GetComponent<MovementPlayer>() == null) return;

            if (_relevantDesk != null)
            {

            }
        };

        OnStart();
    }

    protected virtual void OnStart() { }

    protected void Initialize(TestDesk prefab)
    {
        _deskPrefab = prefab;

        for (int i = 0; i < _capasity; i++)
        {
            Spawn(prefab);
        }
    }

    private void Spawn(TestDesk prefab)
    {
        TestDesk spawned = Instantiate(prefab, _contaner);

        spawned.gameObject.SetActive(false);

        _pool.Add(spawned);
    }

    protected bool TryGetGameObject(out TestDesk result)
    {
        result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);

        return result;
    }

    private TestDesk GetRelevantDesk()
    {
        if (_pool.Count == 0)
        {
            return null;
        }

        float minDistance = Mathf.Infinity;
        int nearestDeskIndex = 0;
        int indexCounter = 0;

        foreach (TestDesk desk in _pool)
        {
            float distance = Vector3.Distance(desk.transform.position, _player.transform.position);

            if (distance < minDistance)
            {
                nearestDeskIndex = indexCounter;
                minDistance = distance;
            }

            indexCounter++;
        }

        return _pool[nearestDeskIndex];
    }

    private void OutDesk()
    {

        StartCoroutine(TakeDesk());
    }

    private IEnumerator TakeDesk()
    {
        while (!_stack.IsFull)
        {            
            _relevantDesk = GetRelevantDesk();
            _relevantDesk.GetComponent<StartMovementDesk>().enabled = false;
            _stack.AddDesk(_relevantDesk);

            _pool.Remove(_relevantDesk);

            Spawn(_deskPrefab);
            yield return new WaitForSeconds (0.3f);
        }        
    }
}
