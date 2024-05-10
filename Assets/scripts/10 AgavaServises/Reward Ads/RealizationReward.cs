using Gameplay.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealizationReward : MonoBehaviour
{
    [SerializeField] private RewardService _rewardService;
    [SerializeField] private TriggerHandler _triggerHandler;
    [SerializeField] private SpawnerMoney _spawnerMoney;
    [SerializeField] private float _delay;
    [SerializeField] private float _delaySpawn;
    [SerializeField] private int _priceViewing;

    private Coroutine _coroutine;
    private bool _isOpenReward = true;
    private bool _isWorkCoroutine = true;

    private void Start()
    {       
        _triggerHandler.OnEnter += col =>
        {
            if (_isOpenReward == true)
            {
                _rewardService.ShowRewardAds();

                if (_coroutine != null)
                {
                    StopCoroutine(_coroutine);
                }

                _coroutine = StartCoroutine(TakeRewardAds());
            }
        };
    }

    public void OpenSpawner()
    {
        _isWorkCoroutine = true;
        _isOpenReward = true;
        _triggerHandler.gameObject.SetActive(true);
    }   

    private IEnumerator TakeRewardAds()
    {
        yield return new WaitForSeconds(_delay);

        _rewardService.ShowRewardAds();

        _triggerHandler.gameObject.SetActive(false);

        _isOpenReward = false;

        while (_isWorkCoroutine != false)
        {
            for (int i = 0; i < _priceViewing; i++)
            {
                _spawnerMoney.CreateMoney();

                yield return new WaitForSeconds(_delaySpawn);
            }

            _isWorkCoroutine = false;

            yield return null;
        }
    }
}
