using Gameplay.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveur : GameObjectPool
{
    [SerializeField] private Desk _prefabDesk;
    [SerializeField] private Transform _pointSpawne;
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
            if (TryGetComponent(out Desk desk))
            {
                _elepsedTime = 0;

                SetDesk(desk, _pointSpawne.position);
            }
        }
    }

    private void SetDesk(Desk desk, Vector3 spawnPosition)
    {
        desk.gameObject.SetActive(true);
        desk.transform.position = spawnPosition;
    }
}
