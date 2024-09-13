namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double FuelConsumptionModifier = 1.6;
        private const double TruckerFactor = 0.95;
        public Truck(double fuelQuantity, double litersPerKm, double tankCapacity) : base(fuelQuantity, litersPerKm + FuelConsumptionModifier, tankCapacity)
        {
        }

        public override void Refuel(double amount)
        {
            if (FuelQuantity + amount > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }
            
            base.Refuel(amount * TruckerFactor);
        }
    }
}
