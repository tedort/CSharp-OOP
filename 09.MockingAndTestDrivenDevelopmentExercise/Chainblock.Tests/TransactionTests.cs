using System;
using Chainblock.Models;
using Chainblock.Models.Enumerations;
using NUnit.Framework;

namespace Chainblock.Tests
{
    [TestFixture]
    public class TransactionTests
    {
        [Test]
        public void Ctor_CreatesNewInstance()
        {
            Transaction transaction = new Transaction(Constants.ValidId, Constants.ValidSender, Constants.ValidReceiver, Constants.ValidAmount);
            Assert.That(transaction, Is.Not.Null);
            Assert.That(transaction.Id, Is.EqualTo(Constants.ValidId));
            Assert.That(transaction.Status, Is.EqualTo(TransactionStatus.New));
            Assert.That(transaction.Sender, Is.EqualTo(Constants.ValidSender));
            Assert.That(transaction.Receiver, Is.EqualTo(Constants.ValidReceiver));
            Assert.That(transaction.Amount, Is.EqualTo(Constants.ValidAmount));

        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(-78544)]
        public void Ctor_WithInvalidId_ThrowsException(int invalidId)
        {
            Assert.Throws<ArgumentException>(() => new Transaction(invalidId, Constants.ValidSender, Constants.ValidReceiver, Constants.ValidAmount));

        }

        [TestCase("")]
        [TestCase("     ")]
        [TestCase(null)]
        public void Ctor_WithInvalidSender_ThrowsException(string invalidSender)
        {
            Assert.Throws<ArgumentNullException>(() => new Transaction(Constants.ValidId, invalidSender, Constants.ValidReceiver, Constants.ValidAmount));

        }

        [TestCase("")]
        [TestCase("     ")]
        [TestCase(null)]
        public void Ctor_WithInvalidReceiver_ThrowsException(string invalidReceiver)
        {
            Assert.Throws<ArgumentNullException>(() => new Transaction(Constants.ValidId, Constants.ValidSender, invalidReceiver, Constants.ValidAmount));
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(-78544)]
        public void Ctor_WithInvalidAmount_ThrowsException(int invalidAmount)
        {
            Assert.Throws<ArgumentException>(() => new Transaction(Constants.ValidId, Constants.ValidSender, Constants.ValidReceiver, invalidAmount));
        }
    }
}
