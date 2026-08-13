using System;
using UnityEngine;

[Serializable]
public class DragonData : EnemyData
{
    [SerializeField] private int _stomachVolume;
    [SerializeField] private float _sheepPerSecond;

    public int StomachVolume => _stomachVolume;
    public float SheepPerSecond => _sheepPerSecond;
}