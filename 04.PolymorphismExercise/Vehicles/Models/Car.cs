namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double FuelConsumptionModifier = 0.9;
        public Car(double fuelQuantity, double litersPerKm, double tankCapacity) : base(fuelQuantity, litersPerKm + FuelConsumptionModifier, tankCapacity)
        {
        }
    }
}
