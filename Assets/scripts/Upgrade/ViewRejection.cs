using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ViewRejection : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textWallet;
    [SerializeField] private Upgrade _upgrade;

    private void Start()
    {
        _upgrade.OnCanNotBuySpeed += () =>
        {

        };

        _upgrade.OnCanNotBayDesk += () =>
        {

        };

        _upgrade.OnCanNotBayChair += () =>
        {

        };

        _upgrade.OnCanNotBuyMoney += () =>
        {

        };
    }

    private IEnumerator ChangeColore()
    {
        while (true)
        {
            yield return null;
        }
    }
}
