﻿using GildedRose.Console.Proxy;

namespace GildedRose.Console.Rules
{
  public abstract class RuleBase
  {
    public abstract bool IsMatch(ItemProxy item);

    public void UpdateItem(ItemProxy item)
    {
      AdjustQuality(item);
      AdjustSellIn(item);

      if (item.SellIn < 0)
      {
        AdjustQualityForNegativeSellIn(item);
      }
    }

    // templates
    public abstract void AdjustQuality(ItemProxy item);

    public virtual void AdjustSellIn(ItemProxy item)
    {
      item.DecrementSellIn();
    }

    public abstract void AdjustQualityForNegativeSellIn(ItemProxy item);
  }
}
