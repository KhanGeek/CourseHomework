using System;
using UnityEngine;

[Serializable]
public class OrcData : EnemyData
{
    [SerializeField] private float _damage;
    [SerializeField] private Color _skinColor;

    public float Damage => _damage;
    public Color SkinColor => _skinColor;
}
