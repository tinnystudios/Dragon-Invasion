public class ScoreItemCount : ScorePropertyBase
{
    public Inventory Inventory;
    public string Item;
    public int Amount = 1;

    public override float Score(DecisionContext context)
    {
        return Inventory.Count(Item) / (float) Amount;
    }
}