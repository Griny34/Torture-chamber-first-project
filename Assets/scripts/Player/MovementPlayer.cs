using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementPlayer : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private Vector3 _moveVector;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        _moveVector.x = Input.GetAxis(Horizontal);
        _moveVector.z = Input.GetAxis(Vertical);

        _rigidbody.velocity = new Vector3(_moveVector.x * _speed, _rigidbody.velocity.y, _moveVector.z * _speed);
    }
}
