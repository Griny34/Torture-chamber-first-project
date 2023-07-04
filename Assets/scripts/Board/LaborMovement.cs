using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Experimental.GraphView.GraphView;

public class LaborMovement : MonoBehaviour
{  
    [SerializeField] private float _speed;

    private MovmentBoard _movementBoard;
    private Coroutine _coroutine;

    private void Start()
    {
        _movementBoard = GetComponent<MovmentBoard>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.TryGetComponent<PointTaking>(out var pointTaking) == true)
        {
            if (_coroutine != null)
            {
                StopCoroutine(Move());
            }

            _coroutine = StartCoroutine(Move());
            gameObject.transform.SetParent(MovementPlayer.Instance.transform, true);
            _movementBoard.enabled = false;
        }
    }

    private IEnumerator Move()
    {
        while(transform.position != LeftHand.Instance.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, LeftHand.Instance.transform.position, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
