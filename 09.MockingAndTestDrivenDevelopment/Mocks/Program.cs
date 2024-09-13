using Moq;

namespace Mocks
{
    public class Program
    {
        static void Main(string[] args)
        {
            Mock<IPromotionStrategy> mockPromotion = new Mock<IPromotionStrategy>();

            mockPromotion.Setup(p => p.GetPromotion(It.IsAny<decimal>()))
                .Returns(20);

            mockPromotion.Setup(p => p.GetPromotion(44343)).Returns(-100);

            IPromotionStrategy promotion = mockPromotion.Object;

            UsePromotion(promotion);

            Console.WriteLine(mockPromotion.Object.GetPromotion(44343));
        }

        public static void UsePromotion(IPromotionStrategy promotionStrategy)
        {
            Console.WriteLine(promotionStrategy.GetPromotion(100));
        }
    }


}
