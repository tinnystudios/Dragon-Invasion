using UnityEngine;

public class Equipment : MonoBehaviour
{
    public Weapon Weapon;

    public EWeaponType WeaponType => Weapon.WeaponType;

    public void ExecuteWeapon()
    {
        Weapon.Execute();
    }
}