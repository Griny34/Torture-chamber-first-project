using Gameplay.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeterminantSpawner : MonoBehaviour
{
    [SerializeField] private TriggerHandler _chairConstructionArea;
    [SerializeField] private List<SpawnerChair> _spawnersChair;

    private SpawnerChair _currentSpawnerChair;

    private void Start()
    {
        _chairConstructionArea.OnEnter += (col) =>
        {
            if (col.GetComponent<MovementPlayer>() == null) return;
            if (_spawnersChair == null) return;

            _currentSpawnerChair = GetSpawnerChair();

            if(_currentSpawnerChair == null) return;
            _currentSpawnerChair.OutItem();
        };

        _chairConstructionArea.OnExit += (col) =>
        {
            if (_currentSpawnerChair == null) return;
            _currentSpawnerChair.StopMoveDesk();
        };
    }

    private SpawnerChair GetSpawnerChair()
    {
        foreach(SpawnerChair spawnerChair in _spawnersChair)
        {
            if(spawnerChair.IsOpen == true)
            {
                return spawnerChair;
            }
        }

        return null;
    }
}
