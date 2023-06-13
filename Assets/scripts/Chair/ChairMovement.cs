using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _transformHand;

    private void Start()
    {
        _transformHand = FindObjectOfType<RightHand>().GetComponent<Transform>();
    }

    public void TakeChair()
    {
        transform.position = Vector3.MoveTowards(transform.position, _transformHand.position, _speed * Time.deltaTime);
    }
}
