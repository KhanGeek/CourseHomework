using System;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    private const int LeftMouseButton = 0;
    private const int RightMouseButton = 1;
    
    
    private Raycaster _raycaster;
    private GrabEffect grabEffect;

    private void Awake()
    {
        _raycaster = new Raycaster();
        grabEffect = new GrabEffect();
    }

    private void Update()
    {
        if (Input.GetMouseButton(LeftMouseButton))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                grabEffect.Lounch(hit);
            }
        }
        
        if (Input.GetMouseButtonDown(RightMouseButton))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                ExplosionEffect explosionEffect = new ExplosionEffect();
                explosionEffect.Lounch(hit);
            }
        }
    }
}
