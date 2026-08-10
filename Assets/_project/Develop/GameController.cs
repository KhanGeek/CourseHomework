using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private float _resurrectionTime;
    [SerializeField] private StartPointCameraController _startPointCamera;
    
    private Health _characterHealth;
    private Resurrection _characterResurrection;

    private float _timeToDie = 2f;

    private void Start()
    {
        _characterHealth = _character.GetComponent<Health>();
        
        if(_characterHealth == null)
            Debug.Log("Character has no Health Component");

        _characterHealth.Died += OnDied;

        _characterResurrection = new Resurrection(_resurrectionTime, this);
        
        Resurrection();
    }

    private void OnDestroy()
    {
        _characterHealth.Died -= OnDied;
    }

    private void OnDied()
    {
        StartCoroutine(WaitBeforeDieCoroutine());
    }

    private void Resurrection()
    {
        _character.transform.position = _startPoint.position;
        _characterHealth.Ressurect();
        _character.gameObject.SetActive(true);
        
        _startPointCamera.Deactivate();
    }

    private IEnumerator WaitBeforeDieCoroutine()
    {
        yield return new WaitForSeconds(_timeToDie);
        
        _startPointCamera.Activate();
        _character.gameObject.SetActive(false);
        _characterResurrection.Activate(Resurrection);
    }
}
