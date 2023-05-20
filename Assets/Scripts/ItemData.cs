using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData", menuName = "ItemData", order = 1)]
public class ItemData : ScriptableObject
{
    [SerializeField]
    private Sprite _image;
    [SerializeField]
    private string _lable;
    [SerializeField]
    private GameObject _template;

    public Sprite Image => _image;
    public string Lable => _lable;
    public GameObject Template => _template;
}
