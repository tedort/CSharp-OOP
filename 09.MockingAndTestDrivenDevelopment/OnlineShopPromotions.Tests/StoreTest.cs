using Moq;
using OnlineShopPromotions.Tests.Fakes;

namespace OnlineShopPromotions.Tests
{
    [TestFixture]
    public class StoreTest
    {
        [Test]
        public void AddProducts_ShouldWorkAndSaveToDb()
        {
            Mock<IDatabase<Product>> mockDb = new Mock<IDatabase<Product>>();
            mockDb.Setup(db => db.GetAll()).Returns(new List<Product>());

            Store store = new Store(mockDb.Object);

            store.AddProduct(new Product() {Id=-1, Name = "Test Product", Price = 10000000});

            Assert.AreEqual(1, store.Products.Count);
            Assert.IsTrue(store.Products.Any(p => p.Id == -1));
            mockDb.Verify(db => db.Save(It.Is<List<Product>>(p => p.Count == 1 && p.Any(product => product.Id == -1))), Times.Once);
            //Assert.AreEqual(1, mockDb.numberOfSaveCalls);
        }
    }
}
