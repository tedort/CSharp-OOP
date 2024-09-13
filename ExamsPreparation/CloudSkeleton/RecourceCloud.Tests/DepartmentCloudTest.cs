namespace RecourceCloud.Tests
{
    [TestFixture]
    public class DepartmentCloudTest
    {
        private DepartmentCloud departmentCloud;

        [SetUp]
        public void SetUp()
        {
            departmentCloud = new DepartmentCloud();
        }

        [Test]
        public void Ctor_WorksCorrectly()
        {
            Assert.That(departmentCloud, Is.Not.Null);
        }

        [Test]
        public void LogTask_ReturnsCorrectly()
        {
            string[] args = { "2", "label", "details" };
            string result = departmentCloud.LogTask(args);
            Assert.That(result, Is.EqualTo("Task logged successfully."));
            Assert.That(departmentCloud.Tasks.Count, Is.EqualTo(1));
        }

        [Test]
        public void LogTask_ArgsDifferentThanThree()
        {
            string[] args = { "2", "label"};
            Assert.Throws<ArgumentException>(() => departmentCloud.LogTask(args));
        }

        [Test]
        public void LogTask_NullValues()
        {
            string[] args = { "2", "label", null};
            Assert.Throws<ArgumentException>(() => departmentCloud.LogTask(args));
        }

        [Test]
        public void LogTask_TaskAlreadyLogged()
        {
            string[] args = { "2", "label", "details" };
            departmentCloud.LogTask(args);
            string result = departmentCloud.LogTask(args);
            Assert.That(result, Is.EqualTo("details is already logged."));
        }

        [Test]
        public void CreateResource_ReturnsTrue()
        {
            string[] args = { "2", "label", "details" };
            departmentCloud.LogTask(args);
            bool result = departmentCloud.CreateResource();
            Assert.That(departmentCloud.Resources.Count, Is.EqualTo(1));
            Assert.That(departmentCloud.Tasks.Count, Is.EqualTo(0));
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void CreateResource_ReturnsFalse()
        {
            bool result = departmentCloud.CreateResource();
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void TestResource_ReturnsResource()
        {
            string[] args = { "2", "label", "details" };
            departmentCloud.LogTask(args);
            departmentCloud.CreateResource();
            Resource resultResource = departmentCloud.TestResource("details");
            Resource resource = new Resource("details", "label");
            Assert.That(resultResource.IsTested, Is.EqualTo(true));
            Assert.That(resultResource, Is.Not.Null);
        }

        [Test]
        public void TestResource_ReturnsNull()
        {
            Resource resultResource = departmentCloud.TestResource("details");
            Assert.That(resultResource, Is.Null);
        }
    }
}
