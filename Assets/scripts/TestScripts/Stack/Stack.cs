using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    private Vector3 _firstCubePos;
    private Vector3 _currentCubePos;

    [SerializeField] private float _speed;
    [SerializeField] private float _countDesk;
     
    List<GameObject> _cubeList = new List<GameObject>();
    private int _cubeListIndexCounter = 0;

    public void TakeDesk(TestDesk testDesk)
    {
        if (_countDesk <= _cubeList.Count) return;

        _cubeList.Add(testDesk.gameObject);
        if (_cubeList.Count == 1)
        {
            _firstCubePos = GetComponent<MeshRenderer>().bounds.max;
            _currentCubePos = new Vector3(testDesk.transform.position.x, _firstCubePos.y, testDesk.transform.position.z);
            testDesk.gameObject.transform.position = _currentCubePos;
            _currentCubePos = new Vector3(testDesk.transform.position.x, transform.position.y + 0.3f, testDesk.transform.position.z);
            testDesk.gameObject.GetComponent<TestDesk>().UpdateCubePosition(transform, true);
        }
        else if (_cubeList.Count > 1)
        {
            testDesk.gameObject.transform.position = _currentCubePos;
            _currentCubePos = new Vector3(testDesk.transform.position.x, testDesk.gameObject.transform.position.y + 0.3f, testDesk.transform.position.z);
            testDesk.gameObject.GetComponent<TestDesk>().UpdateCubePosition(_cubeList[_cubeListIndexCounter].transform, true);
            _cubeListIndexCounter++;
        }
    }
}
