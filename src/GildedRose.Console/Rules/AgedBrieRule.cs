using GildedRose.Console.Proxy;

namespace GildedRose.Console.Rules
{
  public class AgedBrieRule : RuleBase
  {
    public override bool IsMatch(ItemProxy item)
    {
      return item.Name == Constants.Item.AgedBrie;
    }

    public override void AdjustQuality(ItemProxy item)
    {
      item.IncrementQuality();
    }

    public override void AdjustQualityForNegativeSellIn(ItemProxy item)
    {
      item.IncrementQuality();
    }
  }
}
