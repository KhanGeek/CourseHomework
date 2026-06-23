using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : Item
{
    [SerializeField] private float _speedAmount;
    
    public override void Use()
    {
        Moving moving = transform.parent.parent.parent.GetComponent<Moving>();
//не уверен что такой каскад из паррентов верное решение... но другого опять таки не придумал(

        if (moving == null)
        {
            Debug.LogError("не найден компонент Moving");
            return;
        }

        moving.SetSpeed(_speedAmount);
    }
}
