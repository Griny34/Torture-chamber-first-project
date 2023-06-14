using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerChair : MonoBehaviour
{
    [SerializeField] private ChairMovement _prefabChair;
    [SerializeField] private Transform _pointSpawnerChair;
    [SerializeField] private float _countBoard;
    [SerializeField] private float _entryThreshold;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.transform.TryGetComponent<ChairMovement>(out var chairMovement) == true)
        {
            _countBoard++;

            if(_countBoard == _entryThreshold)
            {
                CreatChair();
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if( collider.transform.TryGetComponent<ChairMovement>(out var chairMovement) == true)
        {
            _countBoard = 0;
        }
    }

    private void CreatChair()
    {
        Instantiate(_prefabChair, _pointSpawnerChair.position, Quaternion.identity);
    }
}
