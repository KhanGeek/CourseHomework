using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig")]
public class GameConfig:ScriptableObject
{
    public VictoryCondition VictoryCondition;
    public int VictoryValue;
    public DefeatCondition DefeatCondition;
    public int DefeatValue;

    public float TimeToEnemySpawn = 2f;
}
