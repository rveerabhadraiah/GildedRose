using GildedRose.Console.Proxy;
using GildedRose.Console.Rules;
using System.Collections.Generic;

namespace GildedRose.Console
{

  /// <summary>
  /// Requirements: https://github.com/ardalis/kata-catalog/blob/main/katas/Gilded%20Rose.md 
  /// Code:  https://github.com/NotMyself/GildedRose
  /// Reference: https://app.pluralsight.com/library/courses/design-patterns-overview
  ///  Checkout Demo: Practice with Patterns
  /// Refactored using
  ///  Proxy Pattern = control access to class,
  ///  Rule Based Pattern = break complex logic into simple class each doing one thing,and RulesEngine With applies this rules 
  ///  Builder Pattern = constructs rules engine
  ///  Template Method Pattern = certain steps must happen in sequence in a given set of subclasses
  ///                            and force each subclass to follow that same sequence
  ///                            but customize how each step works based on that subtypes behaviour
  /// </summary>
  public class GildedRose
  {
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
      _items = items;
    }

    public void UpdateQuality()
    {
      foreach (var item in _items)
      {
        UpdateQuality(NewItemProxy(item));
      }
    }

    private ItemProxy NewItemProxy(Item item)
    {
      return new ItemProxy(item);
    }

    private void UpdateQuality(ItemProxy item)
    {
      var engine = ItemQualityRuleEngine.GetBuilder()
        .WithAgedBrieRule()
        .WithBackStagePassesRule()
        .WithConjuredItemRule()
        .WithSulfurasRule()
        .Build();
      engine.ApplyRules(item);
    }
  }
}