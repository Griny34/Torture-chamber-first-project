using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairConstructionArea : MonoBehaviour
{
    

    private void Start()
    {
        
    }

    private void OnTriggerStay(Collider collider)
    {
        if(collider.transform.TryGetComponent<MovementPlayer>(out var movementPlayer) == true)
        {

        }
    }
}
