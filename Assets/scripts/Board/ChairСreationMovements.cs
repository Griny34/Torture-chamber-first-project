using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ChairСreationMovements : MonoBehaviour
{
    [SerializeField] private float _speed;
   
    private Transform _chairArea;

    public bool IsGo { get; set; }

    private void Awake()
    {
        IsGo = false;
    }

    private void Start()
    {
        _chairArea = FindObjectOfType<ChairArea>().GetComponent<Transform>();
    }

    private void Update()
    {
        if(IsGo == true)
        {
            gameObject.transform.SetParent(null);
            Move();
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _chairArea.position, _speed * Time.deltaTime);
    }
}
