namespace Mocks
{
    internal class FakePromotion : IPromotionStrategy
    {
        public decimal GetPromotion(decimal price)
        {
            return 20;
        }
    }
}
