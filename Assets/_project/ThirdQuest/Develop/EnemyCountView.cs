using TMPro;
using UnityEngine;

public class EnemyCountView : MonoBehaviour
{
    [SerializeField] private EnemyDestroyer _destroyer;
    [SerializeField] private TMP_Text _text;

    private void Update()
    {
        _text.text = _destroyer.EnemyCount.ToString();
    }
}
