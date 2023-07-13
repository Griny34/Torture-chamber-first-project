using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ChairСreationMovements : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, ChairArea.Instance.transform.position, _speed * Time.deltaTime);
    }
}
