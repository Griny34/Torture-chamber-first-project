using Gameplay.Common;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ImprovmentSpawner : Improvement
{
    [SerializeField] private Order _order;

    protected override void Change()
    {
        _order.OpenAccess();
    }
}
