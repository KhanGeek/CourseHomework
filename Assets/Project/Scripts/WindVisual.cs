using UnityEngine;

public class WindVisual : MonoBehaviour
{
    [SerializeField] private WindController _windController;

    [SerializeField] private Transform _arrowPrefab;

    private void Update()
    {
        Vector3 direction = _windController.GetDirection();

        _arrowPrefab.rotation = Quaternion.LookRotation(direction);
    }
}
