using GildedRose.Console.Proxy;

namespace GildedRose.Console.Rules
{
  internal class BackStagePassItemRule : RuleBase
  {
    public override bool IsMatch(ItemProxy item)
    {
      return item.Name == Constants.Item.BackstagePasses;
    }

    public override void AdjustQuality(ItemProxy item)
    {
      item.IncrementQuality();

      // between 5 - 10 days
      if (item.SellIn < 11)
      {
        item.IncrementQuality();
      }
      // between 1 - 5 days
      if (item.SellIn < 6)
      {
        item.IncrementQuality();
      }
    }

    public override void AdjustQualityForNegativeSellIn(ItemProxy item)
    {
      item.ResetQuality();
    }
  }
}
