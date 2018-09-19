using System;
using csharp;
using NFluent;
using Xunit;

namespace Tests {
    public class ConjuredItemsTests {
        [Fact]
        public void ConjuredItemsQualityDecreasesTwiceAsFastWhenNotExpired() {
            var conjuredItem = new ConjuredItem { Quality = 4, SellIn = 1 };
            conjuredItem.UpdateQuality();
            Check.That(conjuredItem.Quality).IsEqualTo(2);
        }

        [Fact]
        public void ConjuredItemsQualityDecreasesTwiceAsFastWhenExpired() {
            var conjuredItem = new ConjuredItem { Quality = 4, SellIn = 0 };
            conjuredItem.UpdateQuality();
            Check.That(conjuredItem.Quality).IsEqualTo(0);
        }

        [Fact]
        public void ConjuredItemsQualityCannotDecreaseBelowZero() {
            var conjuredItem = new ConjuredItem { Quality = 1, SellIn = 0 };
            conjuredItem.UpdateQuality();
            Check.That(conjuredItem.Quality).IsZero();
        }
    }
}