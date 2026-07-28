using UnityEngine;

public class PlayerInput : MonoBehaviour, IInputService
{
    [SerializeField] private InputVisual _visual;
    [SerializeField] private InputChanger _inputChanger;

    private bool _firstAidKitSpawnerActive;
    
    private void Update()
    {
        if(HasAppearedNextTargetPoint())
            _inputChanger.PlayerInputActivate();

        if (FirstAidKitSpawnerActiveChange())
            _firstAidKitSpawnerActive = !_firstAidKitSpawnerActive;
    }

    public bool HasAppearedNextTargetPoint() => Input.GetMouseButtonDown(0);
    
    public bool TryGetNextTargetPoint(out Vector3 targetPoint)
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        {
            targetPoint = hit.point;
            
            _visual.SetNextTargetPoint(targetPoint);
            
            return true;
        }
        targetPoint = Vector3.zero;
        return false;
    }

    public void DestroyVisualTargetPoint()
    {
        _visual.DestroyTargetPoint();
        _inputChanger.PlayerInputDeactivate();
    }

    public bool FirstAidKitSpawnerActive() => _firstAidKitSpawnerActive;

    public bool FirstAidKitSpawnerActiveChange() => Input.GetKeyDown(KeyCode.F);
}