using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _spawnParrent;

    [SerializeField] private EnemyDestroyer _destroyer;

    [SerializeField] private float _maxLifeTime;
    [SerializeField] private float _maxEnemyCount;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
            CreateEnemy(DestroyConditions.IsDead);
        
        if(Input.GetKeyDown(KeyCode.Alpha2))
            CreateEnemy(DestroyConditions.AchievedMaxLifeTime);
        
        if(Input.GetKeyDown(KeyCode.Alpha3))
            CreateEnemy(DestroyConditions.ExceededMaxEnemyCount);
    }

    public void CreateEnemy(DestroyConditions destroyCondition)
    {
        Enemy enemy = Instantiate(_enemyPrefab, _spawnParrent);

        switch (destroyCondition)
        {
            case DestroyConditions.IsDead:
                _destroyer.AddEnemy(enemy, () => enemy.IsDead);
                break;
            
            case DestroyConditions.AchievedMaxLifeTime:
                _destroyer.AddEnemy(enemy, () => enemy.LifeTime > _maxLifeTime);
                break;
            
            case DestroyConditions.ExceededMaxEnemyCount:
                _destroyer.AddEnemy(enemy, () => _destroyer.EnemyCount > _maxEnemyCount);
                break;
        }
    }
}
