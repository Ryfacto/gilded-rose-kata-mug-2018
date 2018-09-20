namespace csharp {
    public class AgedBrie : Item {
        
        public override void UpdateQuality() {
            base.UpdateQuality();
            
            SellIn -= 1;
            if (Quality < 50) Quality += 1;
            if (SellIn < 0 && Quality < 50) Quality += 1;
        }
    }
}