using Gameplay.Common;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImprovmentMateriale : Improvement
{
    [SerializeField] private Image _image;

    protected override void Change()
    {
        _image.gameObject.SetActive(true);
    }
}
