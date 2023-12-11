using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMoney : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.TryGetComponent<JoystickPlayer>(out var player) == true)
        {
            Balance.Instance.TakeMoney(Money.Instance.GetMoneyValue());

            _particleSystem.Play();

            Destroy(gameObject, 0.5f);
        }
    } 
}
