using System;
using csharp;
using NFluent;
using Xunit;

namespace Tests {
    public class ConjuredTests {
        [Fact]
        public void ConjuredSellInShouldDecrease() {
            var conjured = new Conjured {
                Name = "Conjured", SellIn = 1, Quality = 4
            };
            conjured.UpdateQuality();
            Check.That(conjured.SellIn).IsZero();
        }

        [Fact]
        public void ConjuredQualityDecreasesTwiceAsFastWhenSellInAboveZero() {
            var conjured = new Conjured {
                Name = "Conjured", SellIn = 1, Quality = 4
            };
            conjured.UpdateQuality();
            Check.That(conjured.Quality).IsEqualTo(2);
        }

        [Fact]
        public void ConjuredQualityDecreasesTwiceAsFastWhenSellInBelowZero() {
            var conjured = new Conjured {
                Name = "Conjured", SellIn = 0, Quality = 4
            };
            conjured.UpdateQuality();
            Check.That(conjured.Quality).IsEqualTo(0);
        }

        [Fact]
        public void ConjuredQualityShouldNotDecreaseBelowZero() {
            var conjured = new Conjured {
                Name = "Conjured", SellIn = 1, Quality = 1
            };
            conjured.UpdateQuality();
            Check.That(conjured.Quality).IsZero();
        }
    }
}