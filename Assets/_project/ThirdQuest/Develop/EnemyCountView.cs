using TMPro;
using UnityEngine;

public class EnemyCountView : MonoBehaviour
{
    [SerializeField] private EnemyCreator _creator;
    [SerializeField] private TMP_Text _text;

    private void Update()
    {
        _text.text = _creator.EnemyCount.ToString();
    }
}
