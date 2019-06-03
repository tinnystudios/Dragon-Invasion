using System.Collections;
using UnityEngine;

public class UseWeaponDecision : Decision
{
    public Equipment Equipment;

    public override IEnumerator Do()
    {
        Equipment.ExecuteWeapon();
        yield return new WaitForSeconds(0.2F);
    }
}