using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMoney : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.TryGetComponent<MovementPlayer>(out var player) == true)
        {
            Balance.Instance.TakeMoney(Money.Instance.GetMoneyValue());
            Destroy(gameObject);
        }
    } 
}
