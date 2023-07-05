using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeftHand : MonoBehaviour
{
    private List<ChairÑreationMovements> _boards = new List<ChairÑreationMovements>();

    public static LeftHand Instance { get; private set;}

    public event UnityAction ChangeBool;

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
        if(collider.transform.TryGetComponent<ChairÑreationMovements>(out var laborMovement) == true)
        {
            AddBoard(laborMovement); 
            Debug.Log("11111111111111");
        }
    }
    private void AddBoard(ChairÑreationMovements board)
    {
        _boards.Add(board);
    }

    private void RemoveBoard(ChairÑreationMovements board)
    {
        _boards.Remove(board);
    }

    private ChairÑreationMovements KeepLastDesk()
    {
        var last = _boards[_boards.Count - 1];
        _boards.RemoveAt(_boards.Count - 1);
        return last;
    }

    private void ChangIsGo()
    {
        for(int i = _boards.Count; i > 0; i--)
        {
            
        }
    }
    
    private IEnumerator Go()
    {
        while(_boards.Count == 0)
        {

            yield return new WaitForSeconds(2f);
        }
    }
}
