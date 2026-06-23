using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Item _itemPrefab;
    [SerializeField] private Transform _spawnPoint;

    private Item _item;

    private void Start() => _item = Instantiate(_itemPrefab, _spawnPoint.position, _spawnPoint.rotation);

    public Item GetItem() => _item;//как правильно удалять ссылку из спавнера? в голову приходит только второй метод
    //или внутри метода создать новую переменную дать ей ссылку, потом к _item приравнять null и вернуть ссылку 
    //с новой переменной
   /* public Item GetItem()
    {
        Item item = _item;
        _item = null;
        return item;
    }*/ //но такое тоже вызывает вопросы
}
