using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BoardsPlayer : MonoBehaviour
{
    [SerializeField] private ChairArea _chairArea;
    [SerializeField] private float _speed;

    private Stack<Chair—reationMovements> _boardsPlayer = new Stack<Chair—reationMovements>();
    private Coroutine coroutine;

    private void OnTriggerStay(Collider collider)
    {
        if(collider.transform.TryGetComponent<ChairConstructionArea>(out var chairConstructionArea) == true)
        {
            if (_chairArea.IsOccupied == false)
            {
                if(coroutine != null)
                {
                    StopCoroutine(coroutine);
                }

                coroutine = StartCoroutine(GoBoards(_boardsPlayer.Peek()));
                _boardsPlayer.Peek().transform.SetParent(null);
                _boardsPlayer.Pop();
                
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.transform.TryGetComponent<ChairConstructionArea>(out var chairConstructionArea) == true)
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }
        }
    }

    public void AddBoard(Chair—reationMovements chairConstructionArea)
    {
        _boardsPlayer.Push(chairConstructionArea);
        Debug.Log("!!!!!!!!!");
    }

    private IEnumerator GoBoards(Chair—reationMovements nextBoard)
    {
        while (nextBoard.transform.position != _chairArea.transform.position)
        {
            nextBoard.transform.position = Vector3.MoveTowards(nextBoard.transform.position, _chairArea.transform.position, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
