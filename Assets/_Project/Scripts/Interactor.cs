using System;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    private const int LeftMouseButton = 0;
    private const int RightMouseButton = 1;
    
    private Raycaster _raycaster;

    private void Awake()
    {
        _raycaster = new Raycaster();
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Input.GetMouseButton(LeftMouseButton))
        {
            
        }
        
        if (Input.GetMouseButtonDown(RightMouseButton))
        {
            
        }
    }
}
