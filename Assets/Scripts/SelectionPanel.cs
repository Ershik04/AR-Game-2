using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionPanel : MonoBehaviour
{
    [SerializeField]
    private ObjectPlacer _objectPlacer;
    [SerializeField]
    private GameObject _itemTemplate;
    [SerializeField]
    private ItemData[] _itemData;
    [SerializeField]
    private Transform _contanier;

    private void Start()
    {
        for (int i = 0; i < _itemData.Length; i++)
        {
            AddItem(_itemData[i]);
        }
    }

    private void AddItem(ItemData itemData)
    {
        Instantiate(_itemTemplate, _contanier).TryGetComponent(out ItemView itemView);
        itemView.Initialize(itemData);
        itemView.ItemSelected += OnItemSelected;
        itemView.ItemDisabled += OnItemDisabled;
    }

    private void OnItemSelected(ItemData itemData)
    {
        _objectPlacer.SetInstaledObject(itemData);
    }

    private void OnItemDisabled(ItemView itemView)
    {
        itemView.ItemSelected -= OnItemSelected;
        itemView.ItemDisabled -= OnItemDisabled;
    }
}
