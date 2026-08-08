using UnityEngine;

public class ObstacleService:MonoBehaviour
{
    [SerializeField] private ObstacleChecker _groundChecker;
    [SerializeField] private ObstacleChecker _leftWallChecker;
    [SerializeField] private ObstacleChecker _rightWallChecker;
    [SerializeField] private ObstacleChecker _cellChecker;
    
    public bool IsGrounded => _groundChecker.IsTouches;
    
    public bool IsTouchingWalls => _leftWallChecker.IsTouches || _rightWallChecker.IsTouches;
    
    public bool IsTouchingCell => _cellChecker.IsTouches;
}
