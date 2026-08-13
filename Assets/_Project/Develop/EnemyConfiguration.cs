using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConfiguration : MonoBehaviour
{
    [SerializeField] private List<DragonData> _dragonDatas;
    [SerializeField] private List<ElfData> _elfDatas;
    [SerializeField] private List<OrcData> _orcDatas;
    [SerializeField] private Spawner _spawner;

    private void Start()
    {
        List<EnemyData> enemyDatas = new List<EnemyData>();
        
        enemyDatas.AddRange(_dragonDatas);
        enemyDatas.AddRange(_elfDatas);
        enemyDatas.AddRange(_orcDatas);
        
        _spawner.Begin(enemyDatas);
    }
}
