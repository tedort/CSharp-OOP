namespace OnlineShopPromotions.Tests
{
    [TestFixture]
    public class PromotionTest
    {
        [Test]
        public void FridayPromotion_ShouldBe50Percent()
        {
            Promotion promotion = new Promotion(new DateTime(2024, 03, 22));
            Assert.AreEqual(50, promotion.GetDiscountedPrice(100));
        }

        [Test]
        public void FirstOfApril2030Promotion_ShouldBe50Percent()
        {
            Promotion promotion = new Promotion(new DateTime(2030, 04, 01));
            Assert.AreEqual(250, promotion.GetDiscountedPrice(100));
        }
    }
}