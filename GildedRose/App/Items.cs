using System.Collections.Generic;
using csharp;

public static class Items {
    public static List<Item> CreateDefaultItems() {
        return new List<Item> {
            new NormalItem { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
            new AgedBrieItem { Name = "Aged Brie", SellIn = 2, Quality = 0 },
            new NormalItem { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
            new SulfurasItem { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
            new SulfurasItem { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
            new BackstagePassesItem {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
            },
            new BackstagePassesItem {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
            },
            new BackstagePassesItem {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
            },
            // this conjured item does not work properly yet
            new NormalItem { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
        };
    }
}