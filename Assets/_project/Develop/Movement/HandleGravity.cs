public class HandleGravity
{
    private const float NormalGravityMultiplier = 1f;
    private float _wallGravityMultiplier;
    private float _gravity;

    ObstacleService _obstacleService;

    public HandleGravity(ObstacleService obstacleService, float gravity, float wallGravityMultiplier)
    {
        _obstacleService = obstacleService;
        _gravity = gravity;
        _wallGravityMultiplier = wallGravityMultiplier;
    }

    public float Apply(float yVelocity, float deltaTime)
    {
        if (_obstacleService.IsGrounded && yVelocity <= 0f)
            return 0f;

        float multiplier;

        if (_obstacleService.IsTouchingWalls && yVelocity <= 0f)
            multiplier = _wallGravityMultiplier;
        else
            multiplier = NormalGravityMultiplier;
        
        return yVelocity - multiplier * _gravity * deltaTime;
    }
}
