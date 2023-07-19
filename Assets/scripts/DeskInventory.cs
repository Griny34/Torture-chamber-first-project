using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskInventory : MonoBehaviour
{
    [SerializeField] private MovementPlayer _player;
    [SerializeField] private float _interval;

    private List<Desk> _desks = new List<Desk>();
    
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void AddDesk(Desk desk)
    {
        _desks.Add(desk);
    }

    private void CreatePoint()
    {
        GameObject point = new GameObject();

        _interval++;

        Vector3 gap = new Vector3(0, _interval, 0);

        point.transform.position = _player.transform.position + gap;
    }

    private void RemoveDesk(Desk desk)
    {
        _desks.Remove(desk);
    }
}
