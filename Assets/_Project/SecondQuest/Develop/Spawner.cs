using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnArea;
    [SerializeField] private Dragon _dragonPrefab;
    [SerializeField] private Elf _elfPrefab;
    [SerializeField] private Orc _orcPrefab;

    public void Begin(List<EnemyData> enemies) => StartCoroutine(spawnCoroutine(enemies));

    private Enemy Spawn(EnemyData enemyData)
    {
        switch (enemyData)
        {
            case DragonData dragonData:
                Dragon dragon = Instantiate(_dragonPrefab, _spawnArea);
                dragon.Initialize(dragonData);
                return dragon;

            case ElfData elfData:
                Elf elf = Instantiate(_elfPrefab, _spawnArea);
                elf.Initialize(elfData);
                return elf;

            case OrcData orcData:
                Orc orc = Instantiate(_orcPrefab, _spawnArea);
                orc.Initialize(orcData);
                return orc;
        }
        
        return null;
    }

    private IEnumerator spawnCoroutine(List<EnemyData> enemies)
    {
        foreach (EnemyData enemyData in enemies)
        {
            Spawn(enemyData).LogStats();
            yield return null;
        }
    }
}
