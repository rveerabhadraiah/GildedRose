using GildedRose.Console;
using System.Collections.Generic;
using Xunit;
using static GildedRose.Console.Constants.Item;

namespace GildedRose.Tests
{
  public class GildedRoseUpdateQualityGivenSulfurasTest
  {
    private readonly List<Item> _items = new List<Item>();
    private readonly Item _item;
    private readonly Console.GildedRose _service;
    private const int InitialQuality = 10;
    private const int InitialSellIn = 10;

    public GildedRoseUpdateQualityGivenSulfurasTest()
    {
      _service = new Console.GildedRose(_items);
      _item = GetSulfuras();
      _items.Add(_item);
    }

    private Item GetSulfuras()
    {
      return new Item { Name = Sulfuras, Quality = InitialQuality, SellIn = InitialSellIn };
    }

    [Fact]
    public void DoesNotDecreaseSulfurasQuality_PositiveSellInDays()
    {
      _service.UpdateQuality();
      Assert.Equal(InitialQuality, _item.Quality);
    }

    [Fact]
    public void DoesNotDecreaseSulfurasQuality_NonPositiveSellInDays()
    {
      _item.SellIn = -1;
      _service.UpdateQuality();
      Assert.Equal(InitialQuality, _item.Quality);
    }

    [Fact]
    public void DoesNotDecrease_SellInDays()
    {
      _service.UpdateQuality();
      Assert.Equal(InitialSellIn, _item.SellIn);
    }

  }
}
