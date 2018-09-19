namespace csharp {

    public class Item {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public virtual void UpdateQuality() {
            SellIn -= 1;
        }
    }

    public static class ItemExtension {
        public static void DecreaseQuality(this Item item, int factor = 1) {
            if (item.Quality > 0) {
                item.Quality -= factor;
            }
        }

        public static void IncreaseQuality(this Item item, int factor = 1) {
            if (item.Quality < 50) {
                item.Quality += factor;
            }
        }
    }

    public class SulfurasItem : Item {
        public override void UpdateQuality() {
            // no-op as quality never decrease for this god item
        }
    }

    public class AgedBrieItem : Item {
        public override void UpdateQuality() {
            base.UpdateQuality();

            this.IncreaseQuality();
            if (SellIn < 0) this.IncreaseQuality();
        }
    }

    public class BackstagePassesItem : Item {
        public override void UpdateQuality() {
            base.UpdateQuality();
            this.IncreaseQuality();
            if (SellIn < 10) this.IncreaseQuality();
            if (SellIn < 5) this.IncreaseQuality();
            if (SellIn < 0) Quality = 0;
        }
    }

    public class NormalItem : Item {
        public override void UpdateQuality() {
            base.UpdateQuality();
            this.DecreaseQuality();
            if (SellIn < 0) this.DecreaseQuality();
        }
    }

    public class ConjuredItem : Item {
        public override void UpdateQuality() {
            base.UpdateQuality();
            if (Quality == 0) return;

            this.DecreaseQuality(2);
            if (SellIn < 0) this.DecreaseQuality(2);
            if (Quality < 0) Quality = 0;
        }
    }
}