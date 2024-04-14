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

    private List<int> _numberMoney = new List<int> { 1,1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,4,4,4,10};
    private Coroutine _coroutine;
    private int repetitions;
    private bool isOpenReward = true;

    private void Start()
    {
        if (isOpenReward == false) return;

        _triggerHandler.OnEnter += col =>
        {
            _rewardService.ShowRewardAds(StartCorutineAds);          
        };

        _triggerHandler.OnExit += col => 
        { 
            if(_coroutine != null)
            {
                StopCoroutine(_coroutine); 
            }
        };
    }

    public void OpenSpawner()
    {
        isOpenReward = true;
    }
    
    private void StartCorutineAds()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(TakeRewardAds());
    }

    private IEnumerator TakeRewardAds()
    {
        int number = Random.RandomRange(0, _numberMoney.Count);

        repetitions = _numberMoney[number];

        while (isOpenReward != false)
        {
            yield return new WaitForSeconds(_delay);

            _rewardService.ShowRewardAds();

            for (int i = 0; i < repetitions; i++)
            {
                _spawnerMoney.CreateMoney();

                yield return new WaitForSeconds(_delaySpawn);
            }

            isOpenReward = false;

            yield return null;
        }
    }
}
