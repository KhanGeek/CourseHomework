using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configs/CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    public Character CharacterPrefab;
    public float Speed = 9;
    public float MaxHealth = 100;
    
    public float TimeToNextTarget = 5f;
}