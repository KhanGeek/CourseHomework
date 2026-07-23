using UnityEngine;

public class PlayerInput : MonoBehaviour, IInputService
{
    [SerializeField] private InputVisual _visual;
    
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

    public void DestroyVisualTargetPoint() => _visual.DestroyTargetPoint();
}