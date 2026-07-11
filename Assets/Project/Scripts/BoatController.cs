using UnityEngine;

public class BoatController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _boatSpeed;
    [SerializeField] private Transform _sail;
    [SerializeField] private WindController _windController;
    
    [SerializeField] private Rotator _boatRotator;
    [SerializeField] private Rotator _sailRotator;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W)) _boatRotator.TurnLeft();

        if (Input.GetKey(KeyCode.Q)) _boatRotator.TurnRight();

        if (Input.GetKey(KeyCode.S)) _sailRotator.TurnLeft();

        if (Input.GetKey(KeyCode.A)) _sailRotator.TurnRight();
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(transform.forward * GetBoatSpeed() * Time.fixedDeltaTime);
    }

    public float GetBoatSpeed()
    {
        Vector3 boatDirection = transform.forward;

        Vector3 sailDirection = _sail.forward;

        Vector3 windDirection = _windController.GetDirection();

        float ScalarBoatAndSailDirection = GetPositiveScalarProduct(boatDirection, sailDirection);

        float ScalarSailAndWindDirection = GetPositiveScalarProduct(windDirection, sailDirection);

        return ScalarBoatAndSailDirection * ScalarSailAndWindDirection * _boatSpeed;
    }

    private float GetPositiveScalarProduct(Vector3 firstDirection, Vector3 secondDirection)
    {
        float ScalarProduct = Vector3.Dot(firstDirection, secondDirection);
        
        if(ScalarProduct < 0)
            ScalarProduct = 0;
        
        return ScalarProduct;
    }
}
