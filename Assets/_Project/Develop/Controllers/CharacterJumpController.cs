using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterJumpController
{
    private float _speed;
    private NavMeshAgent _agent;
    private MonoBehaviour _monoBehaviour;
    private AnimationCurve _jumpCurve;
    
    private Coroutine _jumpCoroutine;

    public CharacterJumpController(
        float speed, 
        NavMeshAgent agent, 
        MonoBehaviour monoBehaviour, 
        AnimationCurve jumpCurve)
    {
        _speed = speed;
        _agent = agent;
        _monoBehaviour = monoBehaviour;
        _jumpCurve = jumpCurve;
    }
    
    public bool InProcess => _jumpCoroutine != null;

    public void Jump(OffMeshLinkData offMeshLinkData)
    {
        if(InProcess)
            return;
        
        _jumpCoroutine=_monoBehaviour.StartCoroutine(JumpCoroutine(offMeshLinkData));
    }

    private IEnumerator JumpCoroutine(OffMeshLinkData offMeshLinkData)
    {
        Vector3 startPosition = offMeshLinkData.startPos;
        Vector3 endPosition = offMeshLinkData.endPos;

        float duration = Vector3.Distance(startPosition, endPosition) / _speed;
        float progress = 0f;

        while (progress<duration)
        {
            float yOffset = _jumpCurve.Evaluate(progress / duration);
            _agent.transform.position =
                Vector3.Lerp(startPosition, endPosition, progress / duration) + Vector3.up * yOffset;
            progress += Time.deltaTime / duration;
            yield return null;
        }
        
        _agent.CompleteOffMeshLink();
        _jumpCoroutine = null;
    }
}
