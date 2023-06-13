using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Experimental.GraphView.GraphView;

public class LaborMovement : MonoBehaviour
{  
    [SerializeField] private float _speed;

    private Transform _transform;
    private MovmentBoard _board;
    private MovementPlayer _player;
    private Coroutine _coroutine;

    private void Start()
    {
        _transform = FindObjectOfType<LeftHand>().GetComponent<Transform>();
        _player = FindObjectOfType<MovementPlayer>().GetComponent<MovementPlayer>();
        _board = GetComponent<MovmentBoard>();
    }

    /*private void OnTriggerEnter(Collider collision)
    {
        transform.position = Vector3.MoveTowards(transform.position, _transform.position, _speed);
        //transform.position = Vector3.Lerp(transform.position, _transform.position, _speed);
        gameObject.transform.SetParent(_player.transform, true);
        _board.enabled = false;
    }*/


    private void OnTriggerStay(Collider collision)
    {
        if(collision.transform.TryGetComponent<PointTaking>(out var pointTaking) == true)
        {
            if(_coroutine != null)
            {
                StopCoroutine(Move());
            }

            _coroutine = StartCoroutine(Move());
            gameObject.transform.SetParent(_player.transform, true);
            _board.enabled = false;
        }
    }

    private IEnumerator Move()
    {
        while(transform.position != _transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, _transform.position, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
