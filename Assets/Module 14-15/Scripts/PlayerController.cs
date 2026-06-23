using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Moving _moving;
    private Inventory _inventory;
    private Health _health;

    private void Awake()
    {
        _moving = GetComponent<Moving>();
        
        if(_moving == null)
            Debug.LogError("Отсутствует компонент PlayerMoving");
        
        _inventory = GetComponent<Inventory>();
        
        if(_inventory == null)
            Debug.LogError("Отсутствует компонент Inventory");
        
        _health = GetComponent<Health>();
        
        if(_health == null)
            Debug.LogError("Отсутствует компонент Health");
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) 
            UsingItem();
    }

    private void UsingItem()
    {
        if (_inventory.ItemSlotIsEmpty)
        {
            Debug.Log("Предмет отсутствует!");
        }
        else
        {
            _inventory.GetItem().Use();
            _inventory.RemoveItem();
        }
    }
}
