public class FirearmWeapon : Weapon
{
    public int Ammo = 15;
    public int MaxAmmo = 15;

    public override float AvailabilityScore => Ammo / (float) MaxAmmo;

    public override void Execute()
    {
        Ammo -= 1;

        if (Ammo <= 0)
            Ammo = 0;
    }

    public void Reload()
    {
        Ammo = MaxAmmo;
    }
}