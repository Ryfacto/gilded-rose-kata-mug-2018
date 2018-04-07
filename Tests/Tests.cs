using System;
using System.Collections.Generic;
using csharp;
using NUnit.Framework;
using NFluent;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void SecurityTest()
        {
            var legacyItems = CreateItems();
            var newItems = CreateItems();
            var legacyGildedRose = new LegacyGildedRose(legacyItems);
            var gildedRose = new GildedRose(newItems);

            for (int i = 0; i < 1000; i++)
            {
                legacyGildedRose.UpdateQuality();
                gildedRose.UpdateQuality();
                CheckItems("Name", legacyItems, newItems);
                CheckItems("SellIn", legacyItems, newItems);
                CheckItems("Quality", legacyItems, newItems);
            }
        }

        [Test]
        public void ConjuredItemsDecreaseQualityTwiceAsFastAsNormalItems()
        {
            var quality = 6;
            var sellIn = 3;
            var conjuredItem = new Item {Name = "Conjured Mana Cake", SellIn = sellIn, Quality = quality};
            var normalItem = new Item {Name = "Normal Item", SellIn = sellIn, Quality = quality};
            var gildedRose = new GildedRose(new []{ conjuredItem, normalItem });

            gildedRose.UpdateQuality();

            var delta = quality - normalItem.Quality;
            var expectedQuality = quality - delta * 2;
            
            Check.That(conjuredItem.Quality).Equals(expectedQuality);
        }
        
        // test sellin plus bas que 3

        private static void CheckItems(string name, IList<Item> legacyItems, IList<Item> newItems)
        {
            Check.That(legacyItems.Extracting(name)).Equals(newItems.Extracting(name));
        }

        private static IList<Item> CreateItems()
        {
            IList<Item> items = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                }
            };

            return items;
        }
    }
}