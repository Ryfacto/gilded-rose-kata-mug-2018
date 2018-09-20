using System;
using csharp;
using NFluent;
using Xunit;

namespace Tests {
    public class SafetyNet {
        [Fact]
        public void TestLegacy() {
            var refactored = new GildedRose(Program.CreateLegacyItems());
            var legacy = new LegacyGildedRose(Program.CreateLegacyItems());

            for (int i = 0; i < 11; i++) {
                Check.That(refactored.Items.Extracting("SellIn")).IsEqualTo(legacy.Items.Extracting("SellIn"));
                Check.That(refactored.Items.Extracting("Name")).IsEqualTo(legacy.Items.Extracting("Name"));
                Check.That(refactored.Items.Extracting("Quality")).IsEqualTo(legacy.Items.Extracting("Quality"));

                refactored.UpdateQuality();
                legacy.UpdateQuality();
            }
        }
    }
}