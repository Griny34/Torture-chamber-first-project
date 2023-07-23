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

    public void AddDesk(Desk desk)
    {
        _desks.Add(desk);
        desk.StartMove(CreatePoint());
        desk.transform.SetParent(gameObject.transform, true);
    }

    private Transform CreatePoint()
    {
        GameObject point = new GameObject();

        _interval++;

        Vector3 gap = new Vector3(0, _interval, 0);

        point.transform.position = _player.transform.position + gap;

        return point.transform;
    }

    private void RemoveDesk(Desk desk)
    {
        _desks.Remove(desk);
    }
}
