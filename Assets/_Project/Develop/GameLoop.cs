using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    [SerializeField] private Character _character;
    private CharacterMovementAgentController _characterMovementAgentController;

    private void Start() => _characterMovementAgentController = new CharacterMovementAgentController(_character);

    private void Update() => _characterMovementAgentController.Update();

    public CharacterMovementAgentController GetCharacterMovementAgentController() => _characterMovementAgentController;
}
