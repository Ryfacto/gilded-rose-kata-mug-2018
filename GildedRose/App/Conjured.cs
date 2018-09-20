namespace csharp {
    public class Conjured : Item {
        public override void UpdateQuality() {
            base.UpdateQuality();

            SellIn -= 1;
            Quality -= 2;
            if (SellIn < 0) Quality -= 2;
            if (Quality < 0) Quality = 0;
        }
    }
}