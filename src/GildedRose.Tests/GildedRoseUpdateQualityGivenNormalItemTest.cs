using GildedRose.Console;
using System.Collections.Generic;
using Xunit;
using static GildedRose.Console.Constants.Item;


namespace GildedRose.Tests
{
  public class GildedRoseUpdateQualityGivenNormalItemTest
  {

    private readonly List<Item> _items = new List<Item>();
    private readonly Item _item;
    private readonly Console.GildedRose _service;
    private const int InitialQuality = 10;
    private const int InitialSellIn = 20;

    public GildedRoseUpdateQualityGivenNormalItemTest()
    {
      _service = new Console.GildedRose(_items);
      _item = GetNormalItem();
      _items.Add(_item);
    }

    private Item GetNormalItem()
    {
      return new Item { Name = NormalItem, Quality = InitialQuality, SellIn = InitialSellIn };
    }

    [Fact]
    public void ReduceNormalItemQualityBy1_GivenPositiveSellInDays()
    {
      _service.UpdateQuality();
      Assert.Equal(InitialQuality - 1, _item.Quality);
    }

    [Fact]
    public void ReduceNormalItemQualityBy2_GivenNonPositiveSellInDays()
    {
      _item.SellIn = 0;
      _service.UpdateQuality();
      Assert.Equal(InitialQuality - 2, _item.Quality);
    }

    [Fact]
    public void DoesNotReduceQualityBelowZero()
    {
      _item.Quality = 0;
      _service.UpdateQuality();
      Assert.Equal(0, _item.Quality);
    }


    [Theory]
    [InlineData(2)]
    [InlineData(1)]
    [InlineData(0)]
    public void DoesNotReduceQualityBelowZeroGivenNonPositiveSellIn(int initialQuality)
    {
      _item.SellIn = 0;
      _item.Quality = initialQuality;
      _service.UpdateQuality();

      Assert.Equal(0, _item.Quality);
    }


    [Fact]
    public void ReduceNormalItemSellInDayBy1()
    {
      _service.UpdateQuality();
      Assert.Equal(InitialSellIn - 1, _item.SellIn);
    }


    [Fact]
    public void DoesReduceSellInBelowZero()
    {
      _item.SellIn = 0;
      _service.UpdateQuality();
      Assert.Equal(-1, _item.SellIn);
    }


  }
}
