using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class CharacterFactory
{
    public Character CreateCharacter(Vector3 position, CharacterConfig characterConfig)
    {
        Character character = Object.Instantiate(characterConfig.CharacterPrefab, position, Quaternion.identity, null);

        character.Initialize(characterConfig.Speed, new Health(characterConfig.MaxHealth));
        
        return character;
    }
}