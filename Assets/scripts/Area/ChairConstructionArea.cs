using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairConstructionArea : MonoBehaviour
{
    [SerializeField] private ChairArea _chairArea;
    [SerializeField] private CommandGiveBoards _giveBoards;

    private void Start()
    {
        
    }

    private void OnTriggerStay(Collider collider)
    {
        if(collider.transform.TryGetComponent<MovementPlayer>(out var movementPlayer) == true)
        {
            if(_chairArea.IsOccupied == false)
            {
                _giveBoards.GiveBoards();
            }
        }
    }
}
