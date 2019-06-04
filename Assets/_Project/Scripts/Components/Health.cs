using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Action OnHealthDepleted { get; set; }
    public Action<int> OnTakeDamage { get; set; }

    public int CurrentHp = 5;
    public int MaxHp = 5;

    public float Remaining01 => CurrentHp / (float)MaxHp;

    public void TakeDamage()
    {
        CurrentHp--;
        OnTakeDamage?.Invoke(CurrentHp);

        if (CurrentHp <= 0)
        {
            CurrentHp = 0;
            OnHealthDepleted?.Invoke();
        }
    }
}