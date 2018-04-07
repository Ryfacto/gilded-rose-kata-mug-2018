using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                var currentItem = Items[i];

                if (currentItem.Name == "Sulfuras, Hand of Ragnaros")
                {
                    continue;
                }

                var oldSellIn = currentItem.SellIn;
                currentItem.SellIn = currentItem.SellIn - 1;

                if (currentItem.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (currentItem.Quality < 50)
                    {
                        currentItem.Quality = currentItem.Quality + 1;

                        if (oldSellIn < 11)
                        {
                            IncrementQualityIfPossible(currentItem);
                        }

                        if (oldSellIn < 6)
                        {
                            IncrementQualityIfPossible(currentItem);
                        }
                    }

                    if (currentItem.SellIn < 0)
                    {
                        currentItem.Quality = 0;
                    }
                }
                else if (currentItem.Name == "Aged Brie")
                {
                    IncrementQualityIfPossible(currentItem);

                    if (currentItem.SellIn < 0)
                    {
                        IncrementQualityIfPossible(currentItem);
                    }
                }
                else
                {
                    DecrementQualityIfPossible(currentItem);

                    if (currentItem.SellIn < 0)
                    {
                        DecrementQualityIfPossible(currentItem);
                    }                    
                }
            }
        }

        private static void DecrementQualityIfPossible(Item currentItem)
        {
            if (currentItem.Quality > 0)
            {
                currentItem.Quality = currentItem.Quality - 1;

                if (currentItem.Name == "Conjured Mana Cake")
                {
                    currentItem.Quality = currentItem.Quality - 1;
                }
            }
        }

        private static void IncrementQualityIfPossible(Item currentItem)
        {
            if (currentItem.Quality < 50)
            {
                currentItem.Quality = currentItem.Quality + 1;
            }
        }
    }
}