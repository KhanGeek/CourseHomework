using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAgentController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            {
            _agent.SetDestination(Input.mousePosition);
            }
    }
}
