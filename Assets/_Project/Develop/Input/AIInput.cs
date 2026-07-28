using UnityEngine;
using Random = UnityEngine.Random;

public class AIInput : MonoBehaviour, IInputService
{
    [SerializeField] private InputVisual _inputVisual;
    [SerializeField] private float _minChangePointTime;
    [SerializeField] private float _maxChangePointTime;
    [SerializeField] private GameObject _floorParrentGameObject;

    private Bounds _floorBounds;
    
    private float _currentTime;

    private void Start() => GetFloorChildrenBound();

    private void Update() => _currentTime -= Time.deltaTime;

    public bool HasAppearedNextTargetPoint() => _currentTime <= 0;

    public bool TryGetNextTargetPoint(out Vector3 targetPoint)
    {
        targetPoint = new Vector3(Random.Range(_floorBounds.min.x, _floorBounds.max.x), 
            0, Random.Range(_floorBounds.min.z, _floorBounds.max.z));
        
        _inputVisual.SetNextTargetPoint(targetPoint);
        
        SetNewTimer();
        return true;
    }

    public void DestroyVisualTargetPoint() => _inputVisual.DestroyTargetPoint();

    public bool FirstAidKitSpawnerActive() => false;

    private void SetNewTimer() => _currentTime = Random.Range(_minChangePointTime, _maxChangePointTime);

    private void GetFloorChildrenBound()
    {
        Renderer[] renderers = _floorParrentGameObject.transform.GetComponentsInChildren<Renderer>();

        _floorBounds = renderers[0].bounds;

        for (int i = 1; i < renderers.Length; i++) 
            _floorBounds.Encapsulate(renderers[i].bounds);
    }
}
