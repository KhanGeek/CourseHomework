using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class ChangerObjectRigitbody : MonoBehaviour
{
    protected Rigidbody Rigidbody;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();

        if (Rigidbody == null)
            Debug.LogError("Mover needs a Rigidbody component");
    }
}
