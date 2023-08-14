using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchModel : MonoBehaviour
{
    [SerializeField] private MatchModelSO[] _allMatch;

    [Header("Timer")]
    [SerializeField] private Timer _gameTimer;

    public MatchModelSO CurrentMatch => _allMatch[0];

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        _gameTimer.StartTimer(CurrentMatch.Time);

        _gameTimer.OnDone += () =>
        {

        };
    }
}
