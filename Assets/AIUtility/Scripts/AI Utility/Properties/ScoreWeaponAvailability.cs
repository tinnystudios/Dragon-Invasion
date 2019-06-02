public class ScoreWeaponAvailability : ScorePropertyBase
{
    public Equipment Equipment;

    public override float Score(DecisionContext context)
    {
        return Equipment.Weapon.AvailabilityScore;
    }
}