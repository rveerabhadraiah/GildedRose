using GildedRose.Console.Proxy;
using System.Collections.Generic;

namespace GildedRose.Console.Rules
{
  public class ItemQualityRuleEngine
  {
    private readonly List<RuleBase> _rules;

    private ItemQualityRuleEngine(List<RuleBase> rules)
    {
      _rules = rules;
    }

    public static ItemQualityRuleEngine.Builder GetBuilder()
    {
      return new ItemQualityRuleEngine.Builder();
    }

    public void ApplyRules(ItemProxy item)
    {
      foreach (var rule in _rules)
      {
        if (rule.IsMatch(item))
        {
          rule.UpdateItem(item);
          break;
        }
      }
    }

    public class Builder
    {
      private readonly List<RuleBase> _builderRules = new List<RuleBase>();

      public Builder WithAgedBrieRule()
      {
        _builderRules.Add(new AgedBrieRule());
        return this;
      }

      public Builder WithSulfurasRule()
      {
        _builderRules.Add(new SulfurasItemRule());
        return this;
      }

      public Builder WithConjuredItemRule()
      {
        _builderRules.Add(new ConjuredItemRule());
        return this;
      }

      public Builder WithBackStagePassesRule()
      {
        _builderRules.Add(new BackStagePassItemRule());
        return this;
      }

      public ItemQualityRuleEngine Build()
      {
        _builderRules.Add(new NormalItemRule());
        return new ItemQualityRuleEngine(_builderRules);
      }
    }
  }
}
