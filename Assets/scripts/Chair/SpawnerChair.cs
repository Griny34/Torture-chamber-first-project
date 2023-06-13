using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerChair : MonoBehaviour
{
    [SerializeField] private ChairMovement _prefabChair;
    [SerializeField] private Transform _pointSpawnerChair;

    private void CreatChair()
    {
        Instantiate(_prefabChair, _pointSpawnerChair.position, Quaternion.identity);
    }
}
