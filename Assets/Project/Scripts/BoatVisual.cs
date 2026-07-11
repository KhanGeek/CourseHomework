using UnityEngine;

public class BoatVisual : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _speedText;
    [SerializeField] private BoatController _boatController;

    private void Update()
    {
        _speedText.text = $"Скорость плота: {_boatController.GetBoatSpeed()}";
    }
}
