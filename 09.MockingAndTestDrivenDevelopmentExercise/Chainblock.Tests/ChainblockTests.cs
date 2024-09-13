using NUnit.Framework;
using Chainblock.Services;
using Chainblock.Models;
using static Chainblock.Tests.Constants;
using Chainblock.Contracts;
using System;
using Chainblock.Models.Enumerations;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private IChainblock chainblock;
        private ITransaction transaction;

        [SetUp]
        public void Setup()
        {
            transaction = new Transaction(ValidId, ValidSender, ValidReceiver, ValidAmount);
            chainblock = new ChainblockService();
        }

        [Test]
        public void Ctor_CreatesNewInstance()
        {
            ChainblockService chainblock = new ChainblockService();
            Assert.That(chainblock, Is.Not.Null);
            Assert.That(chainblock.Count, Is.EqualTo(0));
        }

        [Test]
        public void Contains_WhenTransaction_NotInDictionary_ReturnsFalse()
        {
            bool expectedResult = false;
            bool result = chainblock.Contains(IdNotInCollection);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Add_HappyPath_AddsTransaction()
        {
            chainblock.Add(transaction);
            Assert.That(chainblock.Count, Is.EqualTo(1));
        }

        [Test]
        public void Add_TransactionAlreadyExists_ThrowsException()
        {
            chainblock.Add(transaction);
            Assert.Throws<InvalidOperationException>( () => 
                chainblock.Add(transaction)
            );
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-7844)]
        public void Contains_IdIsLessThanOrEqualToZero_ThrowsException(int invalidId)
        {
            Assert.Throws<ArgumentException>(() =>
                chainblock.Contains(invalidId)
            );
        }

        [Test]
        public void GetById_HappyPath()
        {
            chainblock.Add(transaction);
            ITransaction result = chainblock.GetById(transaction.Id);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(transaction.Id));
            Assert.That(result.Amount, Is.EqualTo(transaction.Amount));
            Assert.That(result.Sender, Is.EqualTo(transaction.Sender));
            Assert.That(result.Receiver, Is.EqualTo(transaction.Receiver));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10232)]
        public void GetById_IdIsInvalid_ThrowsException(int invalidId)
        {
            chainblock.Add(transaction);
            Assert.Throws<ArgumentException>(() => chainblock.GetById(invalidId));
        }

        [Test]
        public void GetById_NotExistingId_ReturnsNull()
        {
            chainblock.Add(transaction);
            ITransaction result = chainblock.GetById(IdNotInCollection);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void RemoveTransactionById_HappyPath()
        {
            // 1. Arrange
            chainblock.Add(transaction);

            // 2. Act
            chainblock.RemoveTransactionById(transaction.Id);

            // 3. Assert
            Assert.That(chainblock.Count, Is.EqualTo(0));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-23432)]
        public void RemoveTransactionById_IdNotValid_ReturnsNull(int invalidId)
        {
            chainblock.Add(transaction);

            Assert.Throws<ArgumentException>(() => chainblock.RemoveTransactionById(invalidId));
        }

        [Test]
        public void ChangeTransactionStatus_HappyPath_ThrowsException()
        {
            chainblock.Add(transaction);
            chainblock.ChangeTransactionStatus(transaction.Id, TransactionStatus.Successfull);
            Assert.That(transaction.Status, Is.EqualTo(TransactionStatus.Successfull));
        }

        [Test]
        public void ChangeTransactionStatus_TransactionNotExisting_ThrowsException()
        {
            chainblock.Add(transaction);
            Assert.Throws<InvalidOperationException>(() => chainblock.ChangeTransactionStatus(IdNotInCollection, TransactionStatus.Successfull));
        }
    }
}
