namespace RecourceCloud.Tests
{
    [TestFixture]
    public class TaskTest
    {
        private Task task;

        [SetUp]
        public void SetUp()
        {
            task = new Task(5, "label", "details");
        }

        [Test]
        public void Ctor_WorksCorrectly()
        {
            Assert.That(task, Is.Not.Null);
            Assert.That(task.Priority, Is.EqualTo(5));
            Assert.That(task.Label, Is.EqualTo("label"));
            Assert.That(task.ResourceName, Is.EqualTo("details"));
        }
    }
}
