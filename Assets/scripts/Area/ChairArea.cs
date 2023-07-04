using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairArea : MonoBehaviour
{
    public static ChairArea Instance { get; private set; }
    public bool IsOccupied { get; private set; }

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        IsOccupied = false;
    }

    private void OnTriggerStay(Collider collider)
    {
        if(collider.transform.TryGetComponent<ChairMovement>(out var chairMovement) == true)
        {
            IsOccupied = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.transform.TryGetComponent<ChairMovement>(out var chairMovement) == true)
        {
            IsOccupied = false;
        }
    }
}
