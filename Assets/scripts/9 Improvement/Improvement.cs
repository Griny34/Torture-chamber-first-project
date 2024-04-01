using Gameplay.Common;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public abstract class Improvement : MonoBehaviour
{
    [SerializeField] private TriggerHandler _triggerHandler;
    [SerializeField] private float _delayStartAction;
    [SerializeField] private float _speedBay;
    [SerializeField] private int _valueBay;

    [SerializeField] private int _priseOpen;
    [SerializeField] private TextMeshProUGUI _valueOnText;
    [SerializeField] private GameObject _text;

    private int _valueCounter;
    private Coroutine _coroutine;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent<JoystickPlayer>(out JoystickPlayer joystickPlayer) == true)
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(BayZone());
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.TryGetComponent<JoystickPlayer>(out JoystickPlayer joystickPlayer) == true)
        {
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator BayZone()
    {
        yield return new WaitForSeconds(_delayStartAction);

        while (Wallet.Instance.GetMoney() != 0 && _valueCounter <= _priseOpen)
        {
            Wallet.Instance.GiveMoney(_valueBay);

            _valueCounter += _valueBay;

            _valueOnText.text = _valueCounter.ToString();

            if (_valueCounter == _priseOpen)
            {
                gameObject.SetActive(false);
                _text.gameObject.SetActive(false);
                Change();
                _triggerHandler.gameObject.SetActive(true);
            }

            yield return new WaitForSeconds(_speedBay);
        }
    }

    protected virtual void Change() {}
}
