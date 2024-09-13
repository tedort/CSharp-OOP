using System;

namespace CarManager.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private const string Make = "Alfa Romeo";
        private const string Model = "Giulia";
        private const double FuelConsumption = 7.0;
        private const double FuelCapacity = 50;

        private Car alfa;

        [SetUp]
        public void SetUp()
        {
            alfa = new Car(Make, Model, FuelConsumption, FuelCapacity);
        }

        [Test]
        public void Ctor_CorrectParameters_CreatesNewInstance()
        {
            Assert.That(alfa, Is.Not.Null);
            Assert.That(alfa.Make, Is.EqualTo(Make));
            Assert.That(alfa.Model, Is.EqualTo(Model));
            Assert.That(alfa.FuelConsumption, Is.EqualTo(FuelConsumption));
            Assert.That(alfa.Make, Is.EqualTo(Make));
            Assert.That(alfa.FuelAmount, Is.EqualTo(0));
        }

        [Test]
        public void Make_Null_ThrowsException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => new Car(null, Model, FuelConsumption, FuelCapacity));
            Assert.That(ex.Message, Is.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        public void Make_Empty_ThrowsException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => new Car(string.Empty, Model, FuelConsumption, FuelCapacity));
            Assert.That(ex.Message, Is.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        public void Model_Null_ThrowsException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => new Car(Make, null, FuelConsumption, FuelCapacity));
            Assert.That(ex.Message, Is.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        public void Model_Empty_ThrowsException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => new Car(Make, string.Empty, FuelConsumption, FuelCapacity));
            Assert.That(ex.Message, Is.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        public void FuelConsumption_Zero_ThrowsException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => new Car(Make, Model, 0, FuelCapacity));
            Assert.That(ex.Message, Is.EqualTo("Fuel consumption cannot be zero or negative!"));
        }

        [Test]
        public void FuelCapacity_Zero_ThrowsException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => new Car(Make, Model, FuelConsumption, 0));
            Assert.That(ex.Message, Is.EqualTo("Fuel capacity cannot be zero or negative!"));
        }

        [Test]
        public void Refuel_HappyPath_FuelAddedToTank()
        {
            double fuelToRefuel = FuelCapacity - 1;
            alfa.Refuel(fuelToRefuel);
            Assert.That(alfa.FuelAmount, Is.EqualTo(fuelToRefuel));
        }

        [Test]
        public void Refuel_TankOverFlow_FuelAddedToTank()
        {
            double fuelToRefuel = FuelCapacity + 1;
            alfa.Refuel(fuelToRefuel);
            Assert.That(alfa.FuelAmount, Is.EqualTo(FuelCapacity));
        }

        [Test]
        public void Refuel_RefuelZeroOrLessLiters_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => alfa.Refuel(0));
            Assert.Throws<ArgumentException>(() => alfa.Refuel(-1));
        }

        [Test]
        public void Drive_HappyPath_ReducesFuelAmount()
        {
            // 1. Arrange
            double distance = 20;
            alfa.Refuel(FuelCapacity);
            double fuelNeeded = (distance / 100) * FuelConsumption;
            double expectedFuelAmount = alfa.FuelAmount - fuelNeeded;

            // 2. Act
            alfa.Drive(distance);

            // 3. Assert
            Assert.That(alfa.FuelAmount, Is.EqualTo(expectedFuelAmount));
        }

        [Test]
        public void Drive_NotEnoughFuel_ThrowsException()
        {
            double distance = 20;
            Assert.Throws<InvalidOperationException>(() => alfa.Drive(distance));
        }
    }
}