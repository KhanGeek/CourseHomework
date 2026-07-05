using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class ChangerObjectRigitbody : MonoBehaviour
{
    [SerializeField] protected InputBehavior InputBehavior;

    protected Rigidbody Rigidbody;

    private void Awake()
    {
        if (InputBehavior == null)
            Debug.LogError("Mover needs an IInputBehavior component");

        Rigidbody = GetComponent<Rigidbody>();

        if (Rigidbody == null)
            Debug.LogError("Mover needs a Rigidbody component");
    }

    protected abstract void Update();
}
