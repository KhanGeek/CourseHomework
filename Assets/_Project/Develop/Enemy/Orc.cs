using UnityEngine;

public class Orc : EnemyType<OrcData>
{
    private float _damage;
    private Color _skinColor;

    protected override string GetStatInfo() => $"урон: {_damage}, цвет кожи: {_skinColor}";

    protected override void Initial(OrcData typeData)
    {
        _damage = typeData.Damage;
        _skinColor = typeData.SkinColor;
    }
}