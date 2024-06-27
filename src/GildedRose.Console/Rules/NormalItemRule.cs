using GildedRose.Console.Proxy;

namespace GildedRose.Console.Rules
{
  internal class NormalItemRule : RuleBase
  {
    public override bool IsMatch(ItemProxy item)
    {
      return item.Name == Constants.Item.NormalItem;
    }

    public override void AdjustQuality(ItemProxy item)
    {
      item.DecrementQuality();
    }

    public override void AdjustQualityForNegativeSellIn(ItemProxy item)
    {
      item.DecrementQuality();
    }
  }
}
