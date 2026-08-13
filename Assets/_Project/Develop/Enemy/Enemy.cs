using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public abstract void Initialize(EnemyData enemyData);
    
    public void LogStats()
    {
        Debug.Log($"Появился пртивник {GetType().Name}, характеристики: {GetStatInfo()}");
    }

    protected abstract string GetStatInfo();
}