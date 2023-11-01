using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _portrait;
    [SerializeField] private GameObject _landscape;

    private void Update()
    {
        if(Screen.width < Screen.height)
        {
            _portrait.SetActive(true);
            _landscape.SetActive(false);
        }
        else
        {
            _portrait.SetActive(false);
            _landscape.SetActive(true);
        }
    }
}
