using GildedRose.Console;
using System.Collections.Generic;
using Xunit;
using static GildedRose.Console.Constants.Item;

namespace GildedRose.Tests
{
  public class GildedRoseUpdateQualityGivenBackstagePassesTest
  {
    private readonly List<Item> _items = new List<Item>();
    private readonly Item _item;
    private readonly Console.GildedRose _service;
    private const int InitialQuality = 10;
    private const int InitialSellIn = 15;

    public GildedRoseUpdateQualityGivenBackstagePassesTest()
    {
      _service = new Console.GildedRose(_items);
      _item = GetBackStagePasses();
      _items.Add(_item);
    }

    private Item GetBackStagePasses()
    {
      return new Item { Name = BackstagePasses, Quality = InitialQuality, SellIn = InitialSellIn };
    }


    [Theory]
    [InlineData(11)]
    [InlineData(12)]
    [InlineData(13)]
    public void IncreaseBackStagePassesQuality_By1_GivenSellInGt10Days(int initialSellIn)
    {
      _item.SellIn = initialSellIn;
      _service.UpdateQuality();
      Assert.Equal(InitialQuality + 1, _item.Quality);
    }
    [Theory]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    [InlineData(10)]
    public void IncreaseBackStagePassesQuality_By2_GivenSellIn6To10Days(int initialSellIn)
    {
      _item.SellIn = initialSellIn;
      _service.UpdateQuality();
      Assert.Equal(InitialQuality + 2, _item.Quality);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void IncreaseBackStagePassesQuality_By2_GivenSellIn1To5Days(int initialSellIn)
    {
      _item.SellIn = initialSellIn;
      _service.UpdateQuality();
      Assert.Equal(InitialQuality + 3, _item.Quality);
    }


    [Theory]
    [InlineData(50, 11)]
    [InlineData(49, 11)]
    [InlineData(50, 10)]
    [InlineData(49, 10)]
    [InlineData(48, 10)]
    [InlineData(50, 5)]
    [InlineData(49, 5)]
    [InlineData(48, 5)]
    [InlineData(47, 5)]
    public void DoesNotIncreaseQuality_Beyond50_NoMatterHowManyDaysRemain(int initialQuality, int initialSellIn)
    {
      _item.SellIn = initialSellIn;
      _item.Quality = initialQuality;
      _service.UpdateQuality();

      Assert.Equal(50, _item.Quality);
    }

    [Fact]
    public void ReduceBackstagePassesQuality_ToZero_GivenNonPositiveSellInDays()
    {
      _item.SellIn = 0;
      _service.UpdateQuality();

      Assert.Equal(0, _item.Quality);
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
