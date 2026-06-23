using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoost : Item
{
    [SerializeField] private int _healthAmount;

    public override void Use()
    {
        Health health = transform.parent.parent.parent.GetComponent<Health>();
//не уверен что такой каскад из паррентов верное решение... но другого опять таки не придумал(

        if (health == null)
        {
            Debug.LogError("не найден компонент Health");
            return;
        }

        health.AddHealth(_healthAmount);
    }
}
