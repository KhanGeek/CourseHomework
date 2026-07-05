using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class ChangerObjectRigitbody : MonoBehaviour
{
    [SerializeField] protected InputBehavior _inputBehavior;

    protected Rigidbody _rigidbody;

    private void Awake()
    {
        if (_inputBehavior == null)
            Debug.LogError("Mover needs an IInputBehavior component");

        _rigidbody = GetComponent<Rigidbody>();

        if (_rigidbody == null)
            Debug.LogError("Mover needs a Rigidbody component");
    }

    protected abstract void FixedUpdate();
}
