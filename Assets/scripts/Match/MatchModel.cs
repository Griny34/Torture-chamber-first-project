using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MatchModel : MonoBehaviour
{
    public static MatchModel Instace { get; private set; }


    [SerializeField] private InterstishelService _interstishelServise;
    [SerializeField] private MatchModelSO[] _allMatch;
    [SerializeField] private RealizationReward _realizationReward;
    [SerializeField] private YndexLeaderBoardMini _mini;

    [Header("Timer")]
    [SerializeField] private Timer _gameTimer;

    [Header("Improvement")]
    [SerializeField] private ImprovmentSpawner _improvmentSpawnerChair;
    [SerializeField] private ImprovmentArmchair _improvmentSpawnerArmChair;
    [SerializeField] private ImprovmentChairOnWheel _improvmentSpawnerOnWheel;
    [SerializeField] private ImprovmentSpawner _improvmentSpawnerDouble;
    [SerializeField] private ImprovmentSpawner _improvmentSpawnerTable;
    [SerializeField] private ImprovmentMateriale _improvmentMaterialeLeather;
    [SerializeField] private ImprovmentMateriale _improvmentMaterialeWheel;
    [SerializeField] private ImprovmentWareHouse _improvmentWareHouse;
    [SerializeField] private ImprovmentWareHouse _improvmentWareHouse2;

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
            FinishMatch();
        };
    }

    public void Initialize()
    {
        _gameTimer.StartTimer(CurrentMatch.Time);

        Wallet.Instance.RestartSalary();
        
    }

    public void StartNextMatch()
    {
        _interstishelServise.ShowInterstitial(StartNestLevel);
    }

    private void StartNestLevel()
    {
        SaveGame();

        _mini.SetPlayerScor(Wallet.Instance.GetSalary());

        if (_currentMatchIndex >= _allMatch.Length)
        {
            // logic
            SceneManager.LoadScene(1);
            return;
        }


        _realizationReward.OpenSpawner();
        Time.timeScale = 1;
        _gameTimer.Stop();
        Initialize();
        onMatchChanged?.Invoke();
    }

    public void ExitMenu()
    {
        SaveGame();
        _mini.SetPlayerScor(CounterMoneyOnScene.Instance.GetVolue());
        Wallet.Instance.GiveMoney(CounterMoneyOnScene.Instance.GetVolue());
        CounterMoneyOnScene.Instance.RestartVolue();
        SceneManager.LoadScene(1);
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
    
    private void SaveGame()
    {
        Wallet.Instance.SaveMoney();       

        _improvmentSpawnerChair.SaveValueCounter();
        _improvmentSpawnerArmChair.SaveValueCounter();
        _improvmentSpawnerOnWheel.SaveValueCounter();
        _improvmentSpawnerDouble.SaveValueCounter();
        _improvmentSpawnerTable.SaveValueCounter();
        _improvmentMaterialeLeather.SaveValueCounter();
        _improvmentMaterialeWheel.SaveValueCounter();
        _improvmentWareHouse.SaveValueCounter();
        _improvmentWareHouse2.SaveValueCounter();
    }
}
