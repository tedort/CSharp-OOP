namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database sut;
        private Database db;

        [SetUp]
        public void SetUp()
        {
            db = new Database();
            int[] data = new int[16];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i;
            }
            sut = new Database(data);

        }

        [Test]
        public void Ctor_EmptyWithValidParameter_CreatesNewInstance()
        {
            Assert.That(db, Is.Not.Null);
            Assert.That(db.Count, Is.EqualTo(0));
        }

        [Test]
        public void Ctor_WithValidParameter_CreatesNewInstance()
        {
            Assert.That(sut.Count, Is.EqualTo(16));
        }

        [Test]
        public void Add_HappyPath_ShouldAddAnElement()
        {
            db.Add(5);
            Assert.That(db.Count, Is.EqualTo(1));
        }

        [Test]
        public void Add_OutOfRange_ShouldThrowAnException()
        {
            Assert.Throws<InvalidOperationException>(() => sut.Add(17));
        }

        [Test]
        public void Remove_HappyPath_ShouldRemoveAnElement()
        {
            sut.Remove();
            Assert.AreEqual(15, sut.Count);
        }

        [Test]
        public void Remove_EmptyCollection_ShouldThrowAnException()
        {
            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        [Test]
        public void Fetch_HappyPath_HasTheSameCountAsFirstArray()
        {
            int[] newArray = sut.Fetch();
            Assert.AreEqual(sut.Count, newArray.Length);
        }
    }
}
