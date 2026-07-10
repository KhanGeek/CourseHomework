using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private List<CinemachineVirtualCamera> _cameras;

    private Queue<CinemachineVirtualCamera> _cameraQueue;

    private void Awake() => _cameraQueue = new Queue<CinemachineVirtualCamera>(_cameras);

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
            ActivateNextCamera();
    }

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
