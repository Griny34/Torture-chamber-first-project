using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackMaterial : MonoBehaviour
{
    [SerializeField] private Transform _pointStartStack;
    [SerializeField] private int _maxCountdesk;
    [SerializeField] private int _countDeskForCreatChair;

    private List<Material> _inventoryMateriale = new List<Material>();
    private float _number = 0;

    public bool IsFull => _inventoryMateriale.Count >= _maxCountdesk;

    private void Start()
    {
        Upgrade.Instace.OnBuyDeskInventory += () =>
        {
            _maxCountdesk++;
        };
    }

    public void AddMaterial(Material material)
    {
        _inventoryMateriale.Add(material);

        material.transform.DOJump(_pointStartStack.position + new Vector3(0, 0.025f + _number, 0), 1f, 1, 0.5f).OnComplete(
            () => {
                material.transform.SetParent(_pointStartStack.transform, true);
                material.transform.localPosition = new Vector3(0, 0.025f + _number, 0);
                material.transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
                _number += 0.2f;
            });
    }

    public void RemoveDesk(Material material, Transform pointDestroy)
    {
        if (material == null) return;

        material.transform.SetParent(null);

        material.transform.DOJump(pointDestroy.position, 1, 1, 0.5f).OnComplete(
            () =>
            {
                _inventoryMateriale.Remove(material);
                Destroy(material.gameObject);
                _number -= 0.2f;
            });
    }

    public List<Material> GetListMaterial()
    {
        return _inventoryMateriale;
    }

    public Material GetLastDesk()
    {
        if (_inventoryMateriale.Count <= 0)
        {
            return null;
        }

        return _inventoryMateriale[_inventoryMateriale.Count - 1];
    }
}
