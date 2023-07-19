using Gameplay.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveur : GameObjectPool
{
    [SerializeField] private GameObject _prefabDesk;
    [SerializeField] private Transform _pointSpawner;
    [SerializeField] private float _delay;

    private float _elepsedTime = 0;

    private void Start()
    {
        Initialize(_prefabDesk);
    }

    private void Update()
    {
        _elepsedTime += Time.deltaTime;

        if( _elepsedTime >= _delay)
        {
            if (TryGetComponent(out GameObject desk))
            {
                _elepsedTime = 0;

                SetDesk(desk, _pointSpawner.position);
            }
        }
    }

    private void SetDesk(GameObject desk, Vector3 spawnPosition)
    {
        desk.SetActive(true);
        desk.transform.position = spawnPosition;
    }
}
