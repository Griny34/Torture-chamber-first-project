using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MatchModel : MonoBehaviour
{
    public static MatchModel Instace { get; private set; }

    [SerializeField] private MatchModelSO[] _allMatch;
    [SerializeField] private Enemy _enemyHard;

    [Header("Timer")]
    [SerializeField] private Timer _gameTimer;

    [Header("Events")]
    [SerializeField] private UnityEvent onFinishing;
    [SerializeField] private UnityEvent onFinished;
    [SerializeField] private UnityEvent onMatchChanged;
    [SerializeField] private UnityEvent onWin;

    private int _currentMatchIndex;
    public MatchModelSO CurrentMatch => _allMatch[_currentMatchIndex];

    public event UnityAction OnFinishing
    {
        add => onFinishing?.AddListener(value);
        remove => onFinishing?.RemoveListener(value);
    }

    public event UnityAction OnFinished
    {
        add => onFinished?.AddListener(value);
        remove => onFinished?.RemoveListener(value);
    }

    private void Awake()
    {
        if(Instace != null)
        {
            Destroy(Instace);
            return;
        }

        Instace = this;
    }

    private void Start()
    {
        Initialize();
        _gameTimer.OnDone += () =>
        {
            Wallet.Instance.TakeMoney(Balance.Instance.GetMoney());
            Balance.Instance.StartNewLevel();

            if(Wallet.Instance.GetMoney() > _enemyHard.GetMoneyEnemy())
            {
                onWin?.Invoke();
            }

            FinishMatch();
        };
    }

    public void Initialize()
    {
        _gameTimer.StartTimer(CurrentMatch.Time);       
    }

    public void StartNextMatch()
    {
        _currentMatchIndex++;

        if(_currentMatchIndex >= _allMatch.Length)
        {
            // logic
            SceneManager.LoadScene(1);
            return;
        }

        Time.timeScale = 1;
        _gameTimer.Stop();
        Initialize();
        onMatchChanged?.Invoke();
    }

    private void FinishMatch()
    {
        Time.timeScale = 0;

        onFinishing?.Invoke();

        StartCoroutine(Utils.MakeActionDelay(0f, () =>
        {
            onFinished?.Invoke(); 
        }));
    }


}
