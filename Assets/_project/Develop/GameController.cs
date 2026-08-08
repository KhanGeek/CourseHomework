using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private float _resurrectionTime;
    
    private Health _characterHealth;
    private Resurrection _characterResurrection;

    private void Start()
    {
        _characterHealth = _character.GetComponent<Health>();
        
        if(_characterHealth == null)
            Debug.Log("Character has no Health Component");

        _characterHealth.Died += OnDied;

        _characterResurrection = new Resurrection(_resurrectionTime, this);
    }

    private void OnDestroy()
    {
        _characterHealth.Died -= OnDied;
    }

    private void OnDied()
    {
        _character.gameObject.SetActive(false);
        
        _characterResurrection.Activate(Resurrection);
    }

    private void Resurrection()
    {
        _character.transform.position = _startPoint.position;
        _characterHealth.Ressurect();
        _character.gameObject.SetActive(true);
    }
}
