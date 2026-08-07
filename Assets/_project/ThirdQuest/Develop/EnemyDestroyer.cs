using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer
{
    private List<Enemy> _enemies;
    private MonoBehaviour _monoBehaviour;

    public int EnemyCount => _enemies.Count;

    public EnemyDestroyer(MonoBehaviour monoBehaviour)
    {
        _monoBehaviour = monoBehaviour;
        
        _enemies = new List<Enemy>();
    }

    public void AddEnemy(Enemy enemy, Func<bool> destroyCondition)
    {
        _enemies.Add(enemy);

        _monoBehaviour.StartCoroutine(DestroyCorutine(enemy, destroyCondition));
    }
    
    private IEnumerator DestroyCorutine(Enemy enemy, Func<bool> destroyCondition)
    {
        yield return new WaitUntil(destroyCondition.Invoke);

        GameObject.Destroy(enemy.gameObject);
        _enemies.Remove(enemy);
    }
}
