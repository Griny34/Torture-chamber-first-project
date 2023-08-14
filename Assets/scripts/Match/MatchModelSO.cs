using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchModelSO : MonoBehaviour
{
    [SerializeField] private int _money;
    [SerializeField] private int _time;
    [SerializeField] private int _numberLevel;

    public int Money => _money;
    public int Time => _time;
    public int NumberLevel => _numberLevel;
}
