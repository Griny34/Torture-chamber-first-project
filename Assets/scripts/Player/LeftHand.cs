using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHand : MonoBehaviour
{
    private float _childrenCount = 0;

    private void Update()
    {
        if( _childrenCount != transform.childCount)
        {
            _childrenCount++;
            transform.position += new Vector3(0, 1f, 0);
        }
    }
}
