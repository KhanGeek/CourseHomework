using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    private List<Enemy> _enemies;

    private void Awake()
    {
        _enemies = new List<Enemy>();
    }

    public void AddEnemy(Enemy enemy, Func<bool> destroyCondition)
    {
        _enemies.Add(enemy);

        StartCoroutine(DestroyCorutine(enemy, destroyCondition));
    }
    
    private IEnumerator DestroyCorutine(Enemy enemy, Func<bool> destroyCondition)
    {
        yield return new WaitUntil(destroyCondition.Invoke);

        Destroy(enemy.gameObject);
        _enemies.Remove(enemy);
    }
}
