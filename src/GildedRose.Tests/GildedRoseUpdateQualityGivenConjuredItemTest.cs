using GildedRose.Console;
using System.Collections.Generic;
using Xunit;
using static GildedRose.Console.Constants.Item;


namespace GildedRose.Tests
{
  public class GildedRoseUpdateQualityGivenConjuredItemTest
  {
    private readonly List<Item> _items = new List<Item>();
    private readonly Item _item;
    private readonly Console.GildedRose _service;
    private const int InitialQuality = 10;
    private const int InitialSellIn = 15;

    public GildedRoseUpdateQualityGivenConjuredItemTest()
    {
      _service = new Console.GildedRose(_items);
      _item = GetConjuredItem();
      _items.Add(_item);
    }

    private Item GetConjuredItem()
    {
      return new Item { Name = Conjured, Quality = InitialQuality, SellIn = InitialSellIn };
    }

    [Fact]
    public void ReduceConjuredItemQuality_By2_GivenPositiveSellInDay()
    {
      _service.UpdateQuality();
      Assert.Equal(InitialQuality - 2, _item.Quality);
    }

    [Fact]
    public void ReduceConjuredItemQuality_By4_GivenNonPositiveSellInDay()
    {
      _item.SellIn = 0;
      _service.UpdateQuality();
      Assert.Equal(InitialQuality - 4, _item.Quality);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(0)]
    public void DoesNotReduceQuality_BelowZero(int initialQuality)
    {
      _item.Quality = initialQuality;
      _service.UpdateQuality();

      Assert.Equal(0, _item.Quality);
    }

    [Theory]
    [InlineData(4)]
    [InlineData(3)]
    [InlineData(2)]
    [InlineData(1)]
    [InlineData(0)]
    public void DoesNotReduceQuality_BelowZero_GivenNonPositiveSellInDays(int initialQuality)
    {
      _item.SellIn = 0;
      _item.Quality = initialQuality;
      _service.UpdateQuality();

      Assert.Equal(0, _item.Quality);
    }

    [Fact]
    public void ReduceConjuredItem_SellInBy1Day()
    {
      _service.UpdateQuality();
      Assert.Equal(InitialSellIn - 1, _item.SellIn);
    }

    [Fact]
    public void DoesReduceSellIn_BelowZero()
    {
      _item.SellIn = 0;
      _service.UpdateQuality();
      Assert.Equal(-1, _item.SellIn);
    }

  }
}
