public class ScoreWeaponType : ScorePropertyBase
{
    public Equipment Equipment;
    public EWeaponType WeaponType;

    public override float Score(DecisionContext context)
    {
        return WeaponType == Equipment.WeaponType ? 1 : 0;
    }
}