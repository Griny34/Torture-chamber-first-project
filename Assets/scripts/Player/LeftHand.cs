using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeftHand : MonoBehaviour
{
    private List<Chair�reationMovements> _boards = new List<Chair�reationMovements>();

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
        if(collider.transform.TryGetComponent<Chair�reationMovements>(out var laborMovement) == true)
        {
            AddBoard(laborMovement); 
            Debug.Log("11111111111111");
        }
    }
    private void AddBoard(Chair�reationMovements board)
    {
        _boards.Add(board);
    }

    private void RemoveBoard(Chair�reationMovements board)
    {
        _boards.Remove(board);
    }

    private Chair�reationMovements KeepLastDesk()
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
