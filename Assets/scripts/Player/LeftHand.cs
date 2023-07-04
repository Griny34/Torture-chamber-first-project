using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHand : MonoBehaviour
{
    private List<LaborMovement> _boards = new List<LaborMovement>();

    public static LeftHand Instance { get; private set;}

    private void Start()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.transform.TryGetComponent<LaborMovement>(out var laborMovement) == true)
        {
            _boards.Add(laborMovement); 
            Debug.Log("11111111111111");
        }
    }
    private void AddBoard(LaborMovement board)
    {
        _boards.Add(board);
    }

    private void RemoveBoard(LaborMovement board)
    {
        _boards.Remove(board);
    }

    private LaborMovement KeepLastDesk()
    {
        var last = _boards[_boards.Count - 1];
        _boards.RemoveAt(_boards.Count - 1);
        return last;
    }
}
