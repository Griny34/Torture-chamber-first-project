using Gameplay.Common;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    [SerializeField] private TriggerHandler _playerTrigger;
    [SerializeField] private Transform _pointSpawner;
    [SerializeField] private int _capasity;
    [SerializeField] private MovementPlayer _player;
    [SerializeField] private PointTake _pointTake;

    private List<GameObject> _pool = new List<GameObject>();

    private void Start()
    {
        _playerTrigger.OnEnter += col =>
        {
            if (col.GetComponent<MovementPlayer>() == null) return;

            Debug.Log("Start give to player desk!");
        };
    }
    protected void Initialize(GameObject prefab)
    {
        for(int i = 0; i < _capasity; i++)
        {
            GameObject spawned = Instantiate(prefab, _pointSpawner.transform.position, Quaternion.identity);

            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetGameObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }

    private GameObject GetRelevantDesk()
    {
        float minDistans = Vector3.Distance(_pointTake.transform.position, _player.transform.position);

        foreach (GameObject desk in _pool)
        {
            float Distans = Vector3.Distance(transform.position, _player.transform.position);
           
            if(Distans < minDistans)
            {
                return desk;
            }
        }

        return null;
    }
}
