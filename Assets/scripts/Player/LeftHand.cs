using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeftHand : MonoBehaviour
{
    public static LeftHand Instance { get; private set;}

    [SerializeField] private BoardsPlayer _boardsPlayer;

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
        if(collider.transform.TryGetComponent<Chair—reationMovements>(out var chair—reationMovements) == true)
        {
            _boardsPlayer.AddBoard(chair—reationMovements);
            
        }  
        
        if(collider.transform.TryGetComponent<LaborMovement>(out var laborMovement) == true)
        {
            laborMovement.enabled = false;
        }
    }
}
