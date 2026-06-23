using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory _inventory;
    //как правильно организовать передачу предмета в инвентарь не прямой ссылкой так и не придумал(

    private void Awake()
    {
        _inventory = GetComponent<Inventory>();

        if (_inventory == null)
            Debug.LogError("Ссылка на инвентарь отсутствует");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_inventory.ItemSlotIsEmpty == false)
            return;
        
        Spawner spawner = other.GetComponent<Spawner>();
        
        if (spawner == null) 
            return;
        
        Item item = spawner.GetItem();

        if (item == null)
            return;

        _inventory.AddItem(item);
    }
}