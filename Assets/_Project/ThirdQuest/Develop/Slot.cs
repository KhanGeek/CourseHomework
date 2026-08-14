using UnityEngine;

public class Slot : IReadOnlySlot
{
    private Item _item;
    private int _count;

    public Slot(Item item, int count)
    {
        _item = item;
        _count = count;
    }

    public Item Item => _item;
    public int Count => _count;

    public int HowMuchCanPutInSlot => _item.MaxStack - _count;

    public void PutInSlot(int count)
    {
        if (count > HowMuchCanPutInSlot)
        {
            Debug.LogError("Попытка превысить размер стака!");
            return;
        }

        _count += count;
    }

    public void TakeFromSlot(int count)
    {
        if (count > _count)
        {
            Debug.Log("Попытка взять из слота больше предметов");
            return;
        }

        _count -= count;
    }
}