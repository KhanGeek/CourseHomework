using System;
using System.Collections;
using UnityEngine;

public class Resurrection
{
    private float _resurrectionTime;
    private MonoBehaviour _monoBehaviour;
    private Coroutine _resurrectionCoroutine;

    public Resurrection(float resurrectionTime, MonoBehaviour monoBehaviour)
    {
        _resurrectionTime = resurrectionTime;
        _monoBehaviour = monoBehaviour;
    }

    public void Activate(Action resurrecte)
    {
        if (_resurrectionCoroutine != null)
            return;
        
        _resurrectionCoroutine=_monoBehaviour.StartCoroutine(ResurrectionCoroutine(resurrecte));
    }

    private IEnumerator ResurrectionCoroutine(Action resurrecte)
    {
        yield return new WaitForSeconds(_resurrectionTime);
        
        resurrecte?.Invoke();
        _resurrectionCoroutine = null;
    }
}
