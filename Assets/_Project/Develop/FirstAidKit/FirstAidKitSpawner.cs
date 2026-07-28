using System.Collections;
using UnityEngine;

public class FirstAidKitSpawner
{
    private float _spawnRadius;
    private float _timeToSpawn;
    private FirstAidKit _firstAidKit;
    private MonoBehaviour _monoBehaviour;
    
    private Coroutine _spawnCoroutine;

    public FirstAidKitSpawner(float spawnRadius, 
        float timeToSpawn, 
        FirstAidKit firstAidKit, 
        MonoBehaviour monoBehaviour)
    {
        _spawnRadius = spawnRadius;
        _timeToSpawn = timeToSpawn;
        _firstAidKit = firstAidKit;
        _monoBehaviour = monoBehaviour;
    }

    public void Activate()
    {
        if (_spawnCoroutine == null)
            _spawnCoroutine = _monoBehaviour.StartCoroutine(SpawnCoroutine());
    }

    public void Deactivate()
    {
        if (_spawnCoroutine != null)
            _monoBehaviour.StopCoroutine(_spawnCoroutine);
    }

    private void SpawnFirstAidKit(Vector3 position) => GameObject.Instantiate(_firstAidKit, position, Quaternion.identity);

    private Vector3 GetRandomSpawnPosition()
    {
        Vector2 direction = Random.insideUnitCircle.normalized;
        return _monoBehaviour.transform.position + new Vector3(direction.x, 0, direction.y) * _spawnRadius;
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeToSpawn);
            SpawnFirstAidKit(GetRandomSpawnPosition());
        }
    }
}
