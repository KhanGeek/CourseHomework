using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private InputVisual _visual;

    private bool _firstAidKitSpawnerActive;
    
    private void Update()
    {

        if (FirstAidKitSpawnerActiveChange())
            _firstAidKitSpawnerActive = !_firstAidKitSpawnerActive;
    }

    public bool HasAppearedNextTargetPoint() => Input.GetMouseButtonDown(0);
    
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

    public bool FirstAidKitSpawnerActiveChange() => Input.GetKeyDown(KeyCode.F);
}