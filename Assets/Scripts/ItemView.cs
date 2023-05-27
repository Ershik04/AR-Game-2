using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class ItemView : MonoBehaviour
{
    [SerializeField]
    private Image _image;
    [SerializeField]
    private Button _button;
    [SerializeField]
    private TMP_Text _text;
    private ItemData _data;
    public event UnityAction<ItemData> ItemSelected;
    public event UnityAction<ItemView> ItemDisabled;

    public void Initialize(ItemData itemData)
    {
        _data = itemData;
        _image.sprite = _data.Image;
        _text.text = _data.Lable;
    }

    private void OnSelectionButtonClick()
    {
        ItemSelected?.Invoke(_data);
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnSelectionButtonClick);
    }

    private void OnDisable()
    {
        ItemDisabled?.Invoke(this);
        _button.onClick.RemoveListener(OnSelectionButtonClick);
    }
}
