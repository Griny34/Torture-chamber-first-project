using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    [SerializeField] private string _name;

    public string GetName()
    {
        return _name;
    }
}
