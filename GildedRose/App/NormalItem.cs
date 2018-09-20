namespace csharp {
    public class NormalItem : Item {
        public override void UpdateQuality() {
            base.UpdateQuality();

            SellIn -= 1;
            if (Quality > 0) Quality -= 1;
            if (SellIn < 0 && Quality > 0) Quality -= 1;
        }
    }
}