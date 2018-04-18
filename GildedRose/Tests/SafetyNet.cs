using NFluent;
using System;
using csharp;
using Xunit;

namespace Tests
{
    public class SafetyNet
    {
        [Fact]
        public void TestProgramToGetFullCoverage()
        {
            Program.Main(new[] {""});
        }
        
        [Fact]
        public void TestAgainstLegacy()
        {
            var app = new GildedRose(Items.CreateDefaultItems());
            var legacy = new LegacyGildedRose(Items.CreateDefaultItems());

            for (int i = 0; i < 100; i++)
            {
                Check.That(app.Items.Extracting("Name")).ContainsExactly(legacy.Items.Extracting("Name"));
                Check.That(app.Items.Extracting("SellIn")).ContainsExactly(legacy.Items.Extracting("SellIn"));
                Check.That(app.Items.Extracting("Quality")).ContainsExactly(legacy.Items.Extracting("Quality"));
                
                app.UpdateQuality();
                legacy.UpdateQuality();
            }
        }
    }
}