using System;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    [SerializeField] private FirstAidKit _firstAidKitPrefab;
    [SerializeField] private float _firstAidKitSpawnRadius;
    [SerializeField] private float _firstAidKitTimeToSpawn;
    
    [SerializeField] private Character _character;
    private CharacterController _characterController;

    private void Awake() => _characterController = new CharacterController(_character, 
        new FirstAidKitSpawner(_firstAidKitSpawnRadius, _firstAidKitTimeToSpawn, _firstAidKitPrefab, _character));

    private void Update() => _characterController.Update();

    public CharacterController GetCharacterMovementAgentController() => _characterController;
}
