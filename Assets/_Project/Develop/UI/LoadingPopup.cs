using UnityEngine;
using UnityEngine.UI;

public class LoadingPopup : MonoBehaviour
{
    [SerializeField] private Image _loadingImage;
    [SerializeField] private float _rotationSpeed;

    public void Show() => gameObject.SetActive(true);

    public void Hide() => gameObject.SetActive(false);

    private void Update() => 
        _loadingImage.transform.Rotate(Vector3.forward * Time.deltaTime * _rotationSpeed, Space.World);
}
