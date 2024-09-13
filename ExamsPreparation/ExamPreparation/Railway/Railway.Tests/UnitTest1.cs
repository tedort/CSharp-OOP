namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Tests
    {
        private RailwayStation station;
        [SetUp]
        public void Setup()
        {
            station = new RailwayStation("station");
        }

        [Test]
        public void Test_Ctor()
        {
            Assert.AreEqual("station", station.Name);
            Assert.AreEqual(0, station.ArrivalTrains.Count);
            Assert.AreEqual(0, station.DepartureTrains.Count);
        }

        [Test]
        public void NameNullOrWhiteSpace_ThrowsExcpetion()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var newStation = new RailwayStation(null);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var newStation = new RailwayStation(" ");
            });
        }

        [Test]
        public void NewArrival_ShouldAddToArrivalTrains()
        {
            station.NewArrivalOnBoard("sofia-varna");

            Assert.AreEqual(1, station.ArrivalTrains.Count);
            Assert.AreEqual("sofia-varna", station.ArrivalTrains.Dequeue());
        }

        [Test]
        public void TrainHasArrived_ShouldWorkCorrectly()
        {
            Assert.AreEqual(1, station.TrainHasArrived("sofia-varna"));

            station.NewArrivalOnBoard("sofia-varna");

            Assert.AreEqual(1, station.ArrivalTrains.Count);
            Assert.AreEqual("sofia-varna", station.ArrivalTrains.Dequeue());
        }
    }
}