using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private int _value;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.transform.TryGetComponent<MovementPlayer>(out var player) == true)
        {
            Destroy(gameObject);
            Wallet.Instance.TakeMoney(_value);
        }
    }   
}
