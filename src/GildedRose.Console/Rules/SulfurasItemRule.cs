using GildedRose.Console.Proxy;

namespace GildedRose.Console.Rules
{
  public class SulfurasItemRule : RuleBase
  {
    public override bool IsMatch(ItemProxy item)
    {
      return item.Name == Constants.Item.Sulfuras;
    }

    public override void AdjustSellIn(ItemProxy item)
    {
      // do nothing
    }

    public override void AdjustQuality(ItemProxy item)
    {
      // do nothing
    }

    public override void AdjustQualityForNegativeSellIn(ItemProxy item)
    {
      // do nothing
    }
  }
}
