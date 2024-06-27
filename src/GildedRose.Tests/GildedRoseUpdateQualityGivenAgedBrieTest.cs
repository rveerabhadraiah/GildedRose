using GildedRose.Console;
using System.Collections.Generic;
using Xunit;
using static GildedRose.Console.Constants.Item;

namespace GildedRose.Tests
{
  public class GildedRoseUpdateQualityGivenAgedBrieTest
  {
    private readonly List<Item> _items = new List<Item>();
    private readonly Item _item;
    private readonly Console.GildedRose _service;
    private const int InitialQuality = 10;
    private const int InitialSellIn = 20;

    public GildedRoseUpdateQualityGivenAgedBrieTest()
    {
      _service = new Console.GildedRose(_items);
      _item = GetAgedBrie();
      _items.Add(_item);
    }

    private Item GetAgedBrie()
    {
      return new Item { Name = AgedBrie, Quality = InitialQuality, SellIn = InitialSellIn };
    }

    [Fact]
    public void IncreaseAgedBrieQualityBy1_PositiveSellInDays()
    {
      _service.UpdateQuality();
      Assert.Equal(InitialQuality + 1, _item.Quality);
    }

    [Fact]
    // Once the sell by date has passed, Quality degrades twice as fast
    public void IncreaseAgedBrieQualityBy2_NonPositiveSellInDays()
    {
      _item.SellIn = 0;
      _service.UpdateQuality();
      Assert.Equal(InitialQuality + 2, _item.Quality);
    }

    [Theory]
    [InlineData(48)]
    [InlineData(49)]
    [InlineData(50)]
    public void DoesNotIncreaseQualityAbove50GivenNonPositiveSellInDays(int initialQuality)
    {
      _item.SellIn = 0;
      _item.Quality = initialQuality;
      _service.UpdateQuality();

      Assert.Equal(50, _item.Quality);
    }

    [Fact]
    public void DoesNotIncreaseQualityBeyond50()
    {
      _item.Quality = 50;
      _service.UpdateQuality();
      Assert.Equal(50, _item.Quality);
    }

    [Fact]
    public void DoesReduceSelfInBelowZero()
    {
      _item.SellIn = 0;
      _service.UpdateQuality();

      Assert.Equal(-1, _item.SellIn);
    }

  }
}