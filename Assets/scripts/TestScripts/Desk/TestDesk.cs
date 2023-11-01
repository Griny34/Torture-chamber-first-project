using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDesk : MonoBehaviour
{
    [SerializeField] private StartMovementDesk _startMovementDesk;
    [SerializeField] private float _speed;

    public void UpdateCubePosition(Transform followedCube, bool isFollowStart)
    {
        _startMovementDesk.enabled = false;
        StartCoroutine(StartFollowingToLastCubePosition(followedCube, isFollowStart));
    }

    IEnumerator StartFollowingToLastCubePosition(Transform followedCube, bool isFollowStart)
    {

        while (isFollowStart)
        {
            yield return new WaitForEndOfFrame();
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, followedCube.position.x, _speed * Time.deltaTime),
                transform.position.y,
                Mathf.Lerp(transform.position.z, followedCube.position.z, _speed * Time.deltaTime));
        }
    }
}
