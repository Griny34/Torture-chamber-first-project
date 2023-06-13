using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionBoards : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent<MovmentBoard>(out var board) == true)
        {
            Destroy(collision.gameObject);
        }
    }
}
