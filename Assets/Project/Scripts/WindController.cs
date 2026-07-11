using UnityEngine;
using Random = UnityEngine.Random;

public class WindController : MonoBehaviour
{
    [SerializeField] private float _changeDirectionTime;
    private float _currentTime;
    
    private Vector3 _direction;

    public Vector3 GetDirection() => _direction;

    private void Awake()
    {
        _direction = Vector3.forward;
        
        ChangeDirection();
    }

    private void Update()
    {
        _currentTime -= Time.deltaTime;

        if (_currentTime <= 0)
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        _direction = Quaternion.Euler(0, Random.Range(0, 360), 0) * _direction;
        _currentTime = _changeDirectionTime;
    }
}
