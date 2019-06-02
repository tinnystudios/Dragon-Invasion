using System.Collections;
using UnityEngine;

public class ReloadDecision : Decision
{
    public FirearmWeapon FirearmWeapon;

    public override IEnumerator Do()
    {
        FirearmWeapon.Reload();
        yield return new WaitForSeconds(1.0F);
    }
}