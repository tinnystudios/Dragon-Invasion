using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public EWeaponType WeaponType;

    /// <summary>
    /// Returns a score between 0 - 1
    /// </summary>
    /// <returns></returns>
    public abstract float AvailabilityScore { get; }

    /// <summary>
    /// Execute the Weapon, A firearm would shoot, a sword would swing
    /// </summary>
    public abstract void Execute();
}