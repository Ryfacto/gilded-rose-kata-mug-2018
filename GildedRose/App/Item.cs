namespace csharp {

    public class Item {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public virtual void UpdateQuality() {
            SellIn = SellIn - 1;
        }

        protected void DecreaseQuality() {
            if (Quality > 0) {
                Quality = Quality - 1;
            }
        }

        protected void IncreaseQuality() {
            if (Quality < 50) {
                Quality = Quality + 1;
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

            IncreaseQuality();
            if (SellIn < 0) IncreaseQuality();
        }
    }

    public class BackstagePassesItem : Item {
        public override void UpdateQuality() {
            base.UpdateQuality();
            IncreaseQuality();
            if (SellIn < 10) IncreaseQuality();
            if (SellIn < 5) IncreaseQuality();
            if (SellIn < 0) Quality = 0;
        }
    }

    public class NormalItem : Item {
        public override void UpdateQuality() {
            base.UpdateQuality();
            DecreaseQuality();
            if (SellIn < 0) DecreaseQuality();
        }
    }
}