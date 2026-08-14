using System;
using UnityEngine;

[Serializable]
public class ElfData : EnemyData
{
    [SerializeField] private float _speed;
    [SerializeField] private float _earLenght;

    public float Speed => _speed;
    public float EarLenght => _earLenght;
}
