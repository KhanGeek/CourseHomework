using Cinemachine;
using UnityEngine;

public class StartPointCameraController : MonoBehaviour
{
    private const int _activeValue = 50;
    private const int _deactiveValue = 0;

    [SerializeField] private CinemachineVirtualCamera _startPointCamera;

    public void Activate() => _startPointCamera.Priority = _activeValue;

    public void Deactivate() => _startPointCamera.Priority = _deactiveValue;
}
