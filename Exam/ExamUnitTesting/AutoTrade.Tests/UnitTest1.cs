using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;

namespace AutoTrade.Tests
{
    [TestFixture]
    public class DealerShopTests
    {
        private DealerShop dealerShop;
        private Vehicle vehicle;

        [SetUp]
        public void Setup()
        {
            dealerShop = new DealerShop(2);
            vehicle = new Vehicle("make", "model", 2020);
            dealerShop.AddVehicle(vehicle);
        }

        [Test]
        public void Ctor_WorksCorrectly()
        {
            Assert.That(dealerShop, Is.Not.Null);
            Assert.That(dealerShop.Capacity, Is.EqualTo(2));
        }

        [Test]
        public void Capacity_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new DealerShop(-5));
        }

        [Test]
        public void AddVehicle_ReturnsCorrectly()
        {
            Vehicle anotherVehicle = new Vehicle("make2", "model2", 2021);
            string actual = dealerShop.AddVehicle(anotherVehicle);
            Assert.That(dealerShop.Vehicles.Count, Is.EqualTo(2));
            Assert.That(actual, Is.EqualTo($"Added {anotherVehicle}"));
        }

        [Test]
        public void AddVehicle_ThrowsException()
        {
            dealerShop.AddVehicle(vehicle);
            Assert.Throws<InvalidOperationException>(() => dealerShop.AddVehicle(vehicle));
        }

        [Test]
        public void SellVehicle_ReturnsFalse()
        {
            bool actual = dealerShop.SellVehicle(new Vehicle("ZX", "Drag", 2015));
            Assert.That(actual, Is.EqualTo(false));
        }

        [Test]
        public void SellVehicle_ReturnsTrue()
        {
            bool actual = dealerShop.SellVehicle(vehicle);
            Assert.That(actual, Is.EqualTo(true));
        }

        [Test]
        public void InvertoryReport_ReturnsCorrectly()
        {
            dealerShop.AddVehicle(new Vehicle("ZX", "Drag", 2015));
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Inventory Report");
            sb.AppendLine($"Capacity: {dealerShop.Capacity}");
            sb.AppendLine($"Vehicles: {dealerShop.Vehicles.Count}");

            foreach (Vehicle vehicle in dealerShop.Vehicles)
            {
                sb.AppendLine(vehicle.ToString());
            }

            string actual = sb.ToString().TrimEnd();

            Assert.That(actual, Is.EqualTo(dealerShop.InventoryReport()));
        }
    }
}
