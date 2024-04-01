using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : Furniture
{
    [SerializeField] private int _price;

    protected override int GivePrice()
    {
        return _price;
    }
}
