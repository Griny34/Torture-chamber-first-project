using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorChildren : MonoBehaviour
{
    [SerializeField] private LeftHand _leftHand;
    [SerializeField] private float _gap;

    public float ChildrenCount { get; private set; }

    private void Start()
    {
        ChildrenCount = 1;
    }

    private void Update()
    {
        if (ChildrenCount != transform.childCount)
        {
            ChildrenCount++;
            _leftHand.transform.position += new Vector3(0, _gap, 0);
        }
    }
}
