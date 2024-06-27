using GildedRose.Console;
using System.Collections.Generic;

namespace GildedRose.Tests
{
  public class GildedRoseUpdateQualityGivenConjuredItemTest
  {
    private readonly List<Item> _items = new List<Item>();
    private readonly Item _item;
    private readonly Console.GildedRose _service;
    private const int InitialQuality = 10;
    private const int InitialSellIn = 20;

    public GildedRoseUpdateQualityGivenConjuredItemTest()
    {
      _service = new Console.GildedRose(_items);
      _item = GetConjuredItem();
      _items.Add(_item);
    }

    private Item GetConjuredItem()
    {
      throw new System.NotImplementedException();
    }
  }
}
