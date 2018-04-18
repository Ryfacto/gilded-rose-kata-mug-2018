using NFluent;
using System;
using csharp;
using Xunit;

namespace Tests
{
    public class SafetyNet
    {
        [Fact]
        public void TestDayZero()
        {
            var app = new GildedRose(GildedRose.CreateDefaultItems());

            Check.That(app.Items.Extracting("Name")).ContainsExactly("+5 Dexterity Vest", "Aged Brie",
                "Elixir of the Mongoose", "Sulfuras, Hand of Ragnaros", "Sulfuras, Hand of Ragnaros",
                "Backstage passes to a TAFKAL80ETC concert", "Backstage passes to a TAFKAL80ETC concert",
                "Backstage passes to a TAFKAL80ETC concert", "Conjured Mana Cake");
            Check.That(app.Items.Extracting("SellIn")).ContainsExactly(10, 2, 5, 0, -1, 15, 10, 5, 3);
            Check.That(app.Items.Extracting("Quality")).ContainsExactly(20, 0, 7, 80, 80, 20, 49, 49, 6);
        }

        [Fact]
        public void TestDayOne()
        {
            var app = new GildedRose(GildedRose.CreateDefaultItems());

            app.UpdateQuality();

            Check.That(app.Items.Extracting("Name")).ContainsExactly("+5 Dexterity Vest", "Aged Brie",
                "Elixir of the Mongoose", "Sulfuras, Hand of Ragnaros", "Sulfuras, Hand of Ragnaros",
                "Backstage passes to a TAFKAL80ETC concert", "Backstage passes to a TAFKAL80ETC concert",
                "Backstage passes to a TAFKAL80ETC concert", "Conjured Mana Cake");
            Check.That(app.Items.Extracting("SellIn")).ContainsExactly(9, 1, 4, 0, -1, 14, 9, 4, 2);
            Check.That(app.Items.Extracting("Quality")).ContainsExactly(19, 1, 6, 80, 80, 21, 50, 50, 5);
        }

        [Fact]
        public void TestDayTwo()
        {
            var app = new GildedRose(GildedRose.CreateDefaultItems());

            app.UpdateQuality();
            app.UpdateQuality();

            Check.That(app.Items.Extracting("Name")).ContainsExactly("+5 Dexterity Vest", "Aged Brie",
                "Elixir of the Mongoose", "Sulfuras, Hand of Ragnaros", "Sulfuras, Hand of Ragnaros",
                "Backstage passes to a TAFKAL80ETC concert", "Backstage passes to a TAFKAL80ETC concert",
                "Backstage passes to a TAFKAL80ETC concert", "Conjured Mana Cake");
            Check.That(app.Items.Extracting("SellIn")).ContainsExactly(8, 0, 3, 0, -1, 13, 8, 3, 1);
            Check.That(app.Items.Extracting("Quality")).ContainsExactly(18, 2, 5, 80, 80, 22, 50, 50, 4);
        }

        [Fact]
        public void TestDay1000()
        {
            var app = new GildedRose(GildedRose.CreateDefaultItems());

            for (int i = 0; i < 1000; i++)
            {
                app.UpdateQuality();
            }

            Check.That(app.Items.Extracting("Name")).ContainsExactly("+5 Dexterity Vest", "Aged Brie",
                "Elixir of the Mongoose", "Sulfuras, Hand of Ragnaros", "Sulfuras, Hand of Ragnaros",
                "Backstage passes to a TAFKAL80ETC concert", "Backstage passes to a TAFKAL80ETC concert",
                "Backstage passes to a TAFKAL80ETC concert", "Conjured Mana Cake");
            Check.That(app.Items.Extracting("SellIn")).ContainsExactly(-990, -998, -995, 0, -1, -985, -990, -995, -997);
            Check.That(app.Items.Extracting("Quality")).ContainsExactly(0, 50, 0, 80, 80, 0, 0, 0, 0);
        }
    }
}