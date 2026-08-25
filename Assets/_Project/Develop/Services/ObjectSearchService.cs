using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class ObjectSearchService
{
    public List<Vector3> FindSpawnPoints()
    {
        SpawnPoints spawnPoints = Object.FindObjectOfType<SpawnPoints>();

        if (spawnPoints == null)
            throw new Exception("SpawnPoints not found");

        return new List<Vector3>(spawnPoints.GetSpawnPoints);
    }

    public LevelBound FindLevelBound()
    {
        LevelBound levelBound = Object.FindObjectOfType<LevelBound>();

        if (levelBound == null)
            throw new Exception("Level bound not found");
        
        return levelBound;
    }

    public Vector3 FindPlayerSpawnPointPosition()
    {
        Vector3 playerSpawnPointPosition = GameObject.FindWithTag("PlayerStartPoint").transform.position;
        
        return playerSpawnPointPosition;
    }
}
