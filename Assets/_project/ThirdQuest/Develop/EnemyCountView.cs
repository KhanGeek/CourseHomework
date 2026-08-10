using TMPro;
using UnityEngine;

public class EnemyCountView : MonoBehaviour
{
    [SerializeField] private EnemyCreator _creator;
    [SerializeField] private TMP_Text _text;

    private EnemyDestroyer _destroyer;

    private void Update() => _text.text = _destroyer.EnemyCount.ToString();

    public void Initialize(EnemyDestroyer  destroyer) => _destroyer = destroyer;
}
