using Gameplay.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDeterminateSpawner : MonoBehaviour
{
    [SerializeField] private TriggerHandler _chairConstructionArea;
    [SerializeField] private List<TestSpawnerChair> _spawnersChair;

    private TestSpawnerChair _currentSpawnerChair;

    private void Start()
    {
        _chairConstructionArea.OnEnter += (col) =>
        {
            if (col.GetComponent<JoystickPlayer>() == null) return;
            if (_spawnersChair == null) return;

            _currentSpawnerChair = GetSpawnerChair();

            if (_currentSpawnerChair == null) return;
            _currentSpawnerChair.OutItem();
        };

        _chairConstructionArea.OnExit += (col) =>
        {
            if (_currentSpawnerChair == null) return;
            
        };
    }

    private TestSpawnerChair GetSpawnerChair()
    {
       
        foreach (TestSpawnerChair spawnerChair in _spawnersChair)
        {
            if (spawnerChair.IsOpen == true)
            {
                return spawnerChair;
            }
        }

        return null;
    }
}
