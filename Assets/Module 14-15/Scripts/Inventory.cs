using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Transform _itemPoint;
    
    private Item _item;

    public bool ItemSlotIsEmpty => _item == null;

    public void AddItem(Item item)
    {
        _item = item;
        
        _item.transform.SetParent(_itemPoint);
        _item.transform.localPosition = Vector3.zero;
    }

    public void RemoveItem()
    {
        Destroy(_item.gameObject);
        _item = null;
    }

    public Item GetItem() => _item;
}
