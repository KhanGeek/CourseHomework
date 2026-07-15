using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private List<CinemachineVirtualCamera> _cameras;

    private Queue<CinemachineVirtualCamera> _cameraQueue;
    
    private IInputService _inputService;

    private void Awake() => _cameraQueue = new Queue<CinemachineVirtualCamera>(_cameras);

    private void Update()
    {
        if (_inputService.ChangeCamera()) 
            ActivateNextCamera();
    }

    public void Initialize(IInputService inputService) => _inputService = inputService;

    private void ActivateNextCamera()
    {
        DeactivateAllCamera();
        
        CinemachineVirtualCamera currentCamera = _cameraQueue.Dequeue();
        currentCamera.gameObject.SetActive(true);
        _cameraQueue.Enqueue(currentCamera);
    }

    private void DeactivateAllCamera()
    {
        foreach (CinemachineVirtualCamera camera in _cameras)
            camera.gameObject.SetActive(false);
    }
}
