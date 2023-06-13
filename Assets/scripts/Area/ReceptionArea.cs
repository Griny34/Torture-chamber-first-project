using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptionArea : MonoBehaviour
{
    [SerializeField] private GameObject _area;
    [SerializeField] private ScorChildren _childrenCount;

    private void Start()
    {
        _area.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.transform.TryGetComponent<MovementPlayer>(out var player) == true && _childrenCount.ChildrenCount < 11)
        {
            _area.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.transform.TryGetComponent<MovementPlayer>(out var player) == true && _childrenCount.ChildrenCount >= 11)
        {        
            _area.SetActive(false);            
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.transform.TryGetComponent<MovementPlayer>(out var player) == true)
        {
            _area.SetActive(false);
        }
    }
}
