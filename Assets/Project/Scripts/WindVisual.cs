using UnityEngine;

public class WindVisual : MonoBehaviour
{
    [SerializeField] private WindController _windController;

    [SerializeField] private GameObject _arrowPrefab;

    private void Update()
    {
        Vector3 direction = _windController.GetDirection();

        _arrowPrefab.transform.rotation = Quaternion.LookRotation(direction);
    }
}
