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
            Wallet.Instance.TakeMoney(Money.Instance.GetMoneyValue());

            Wallet.Instance.TakeSalary(Money.Instance.GetMoneyValue());

            CounterMoneyOnScene.Instance.SubtractVolue(); 

            _particleSystem.Play();

            Destroy(gameObject, 0.5f);
        }
    }   
}
