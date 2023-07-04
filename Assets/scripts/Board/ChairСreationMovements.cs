using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ChairСreationMovements : MonoBehaviour
{
    [SerializeField] private float _speed;

    private bool _isGo;

    private void Awake()
    {
        _isGo = false;
    }


    private void Update()
    {
        if(_isGo == true)
        {
            gameObject.transform.SetParent(null);
            Move();
            Destroy(gameObject);
            Debug.Log("44444444");
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, ChairArea.Instance.transform.position, _speed * Time.deltaTime);
    }
}
