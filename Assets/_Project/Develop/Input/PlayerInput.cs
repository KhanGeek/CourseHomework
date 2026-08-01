using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const int LeftMouseButton = 0;
    
    [SerializeField] private InputVisual _visual;

    private bool _firstAidKitSpawnerActive;
    private float _timeTheLastClicked;
    
    private void Update()
    {
        _timeTheLastClicked += Time.deltaTime;
        
        if (Input.GetMouseButton(LeftMouseButton))
            _timeTheLastClicked = 0;
        
        if (FirstAidKitSpawnerActiveChange())
            _firstAidKitSpawnerActive = !_firstAidKitSpawnerActive;
    }

    public bool HasAppearedNextTargetPoint() => Input.GetMouseButtonDown(LeftMouseButton);

    public bool TryGetNextTargetPoint(out Vector3 targetPoint)
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        {
            targetPoint = hit.point;
            
            return true;
        }
        
        targetPoint = Vector3.zero;
        return false;
    }

    public bool FirstAidKitSpawnerActive() => _firstAidKitSpawnerActive;
    
    public float GetTimeTheLastClicked => _timeTheLastClicked;
    
    private bool FirstAidKitSpawnerActiveChange() => Input.GetKeyDown(KeyCode.F);
}