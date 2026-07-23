using UnityEngine;

public interface IInputService
{
    bool HasAppearedNextTargetPoint();
    bool TryGetNextTargetPoint(out Vector3 targetPoint);
    void DestroyVisualTargetPoint();
}
