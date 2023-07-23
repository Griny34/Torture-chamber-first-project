using Gameplay.Common;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    [SerializeField] private TriggerHandler _playerTrigger;
    [SerializeField] private int _capasity;
    [SerializeField] private MovementPlayer _player;
    [SerializeField] private PointTake _pointTake;
    [SerializeField] private DeskInventory _deskInventory;

    private List<Desk> _pool = new List<Desk>();

    private void Start()
    {
        _playerTrigger.OnEnter += col =>
        {
            if (col.GetComponent<MovementPlayer>() == null) return;
            _deskInventory.AddDesk(GetRelevantDesk());
            _pool.Remove(GetRelevantDesk());
            ;
        };
    }
    protected void Initialize(Desk prefab)
    {
        for(int i = 0; i < _capasity; i++)
        {
            Desk spawned = Instantiate(prefab);

            spawned.gameObject.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetGameObject(out Desk result)
    {
        Debug.Log("1");
        result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);
        Debug.Log("2");
        return result != null;
    }

    private Desk GetRelevantDesk()
    {
        float minDistans = Vector3.Distance(_pointTake.transform.position, _player.transform.position);

        foreach (Desk desk in _pool)
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
