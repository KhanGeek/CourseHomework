using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    [SerializeField] private List<Vector3> _spawnPoints = new();

    public IReadOnlyList<Vector3> GetSpawnPoints => _spawnPoints;
    
    [ContextMenu("FindSpawnPoints")]
    private void FindSpawnPoints()
    {
        SpawnPoint[] spawnPoints = FindObjectsByType<SpawnPoint>(FindObjectsSortMode.None);
        
        foreach (SpawnPoint spawnPoint in spawnPoints)
            _spawnPoints.Add(spawnPoint.transform.position);
    }
}
