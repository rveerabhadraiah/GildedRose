using GildedRose.Console.Proxy;

namespace GildedRose.Console.Rules
{
  public class ConjuredItemRule : RuleBase
  {
    public override bool IsMatch(ItemProxy item)
    {
      return item.Name == Constants.Item.Conjured;
    }

    public override void AdjustQuality(ItemProxy item)
    {
      item.DecrementQuality();
      item.DecrementQuality();
    }

    public override void AdjustQualityForNegativeSellIn(ItemProxy item)
    {
      item.DecrementQuality();
      item.DecrementQuality();
    }
  }
}
