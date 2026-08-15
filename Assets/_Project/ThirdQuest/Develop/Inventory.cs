using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory
{
    private List<Slot> _slots = new();
    private int _maxSize;

    public Inventory(int maxSize)
    {
        _maxSize = maxSize;
    }
    
    public Inventory(List<Slot> slots, int maxSize)
    {
        _slots = slots;
        _maxSize = maxSize;
    }

    public IReadOnlyList<IReadOnlySlot> GetReadonlyInventory => _slots;

    private int CurrentSize => _slots.Sum(slot => slot.Count);

    public bool CanAddItem(int count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException("Аргумент не может быть отрицательным!");
        
        if (_maxSize - CurrentSize < count)
        {
            Debug.Log("не хватает места в инвентаре!");
            return false;
        }
        
        return true;
    }

    public void AddItem(Item item, int count)
    {
        if (CanAddItem(count) == false)
        {
            Debug.LogError("Попытка превысить вместимость инвентаря!");
            return;
        }
        
        List<Slot> slots = GetSelectedNameSlots(item.Name);

        foreach (Slot slot in slots)
        {
            if (count <= 0)
                return;

            int howMuchCanPutInSlot = slot.HowMuchCanPutInSlot;

            if (howMuchCanPutInSlot <= 0)
                continue;

            int quantity = Mathf.Min(howMuchCanPutInSlot, count);
            slot.PutInSlot(quantity);
            count -= quantity;
        }

        while (count > 0) 
        {
            int quantity = Mathf.Min(item.MaxStack, count);
            _slots.Add(new Slot(item, quantity));
            count -= quantity;
        }
    }

    public bool CanRemoveItem(Item item, int count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException("Аргумент не может быть отрицательным!");
        
        if (GetSelectedNameSlots(item.Name).Sum(slot => slot.Count) >= count)
            return true;
        
        Debug.Log("Недостаточно предметов");
        return false;
    }

    public void RemoveItem(Item item, int count)
    {
        if(CanRemoveItem(item, count) == false)
            return;
        
        List<Slot> slots = GetSelectedNameSlots(item.Name);

        foreach (Slot slot in slots)
        {
            if (count <= 0)
                return;
            
            int quantity = Mathf.Min(count, slot.Count);
            slot.TakeFromSlot(quantity);
            count -= quantity;
            
            if(slot.Count <= 0)
                _slots.Remove(slot);
        }
    }

    private List<Slot> GetSelectedNameSlots(string name) => _slots.Where(slot => slot.Item.Name == name).ToList();
}