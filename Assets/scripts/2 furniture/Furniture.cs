using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    [SerializeField] private string _name;

    private int _volumePrice;

    public string GetName()
    {
        return _name;
    }
  
    public int GiveVolumePrice()
    {
        return GivePrice();
    }

    protected virtual int GivePrice()
    {
        return _volumePrice;
    }
}
