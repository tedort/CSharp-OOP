namespace RecourceCloud.Tests
{
    [TestFixture]
    public class ResourceTest
    {
        private Resource resource;

        [SetUp]
        public void Setup()
        {
            resource = new Resource("resource", "type");
        }

        [Test]
        public void Ctor_WorksCorrectly()
        {
            Assert.That(resource, Is.Not.Null);
            Assert.That(resource.Name, Is.EqualTo("resource"));
            Assert.That(resource.ResourceType, Is.EqualTo("type"));
            Assert.That(resource.IsTested, Is.EqualTo(false));
        }

        [Test]
        public void IsTested_SetsCorrectly()
        {
            resource.IsTested = true;
            Assert.That(resource.IsTested, Is.EqualTo(true));
        }
    }
}