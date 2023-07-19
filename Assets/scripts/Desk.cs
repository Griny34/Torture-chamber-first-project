using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent(out PointOff pointOff))
        {
            SwitchOffDesk();
        }
    }

    private void StartMove(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
    }

    private void SwitchOffDesk()
    {
        gameObject.SetActive(false);
    }
}
