using UnityEngine;

public abstract class EnemyType<T> : Enemy where T : EnemyData
{
    public override void Initialize(EnemyData enemyData)
    {
        if (enemyData is not T typeData)
        {
            Debug.LogError($"{enemyData.GetType().Name} не соответствует {typeof(T).Name}");
            return;
        }
        
        Initial(typeData);
    }
    
    protected abstract void Initial(T typeData);
}