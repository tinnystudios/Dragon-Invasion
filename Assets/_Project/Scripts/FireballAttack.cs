using System.Collections;
using UnityEngine;

public class FireballAttack : EnemyAttackBase
{
    public Fireball FireballPrefab;
    public Transform Pivot;
    public CoolDown CoolDown;

    public float Power = 3;

    public override void Attack()
    {
        if (CoolDown.IsCoolingDown)
            return;

        var fireball = Instantiate(FireballPrefab, Pivot.position, Pivot.rotation);
        var velocity = Pivot.forward * Power;

        fireball.Fire(velocity);

        CoolDown.Begin();
    }
}