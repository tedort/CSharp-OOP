namespace NeedForSpeed
{
    public class Vehicle
    {
        private int horsePower;
        private double fuel;
        private double fuelConsumption;

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public int HorsePower
        {
            get => horsePower;
            set => horsePower = value;
        }

        public double Fuel
        {
            get => fuel;
            set => fuel = value;
        }

        public virtual double FuelConsumption
        {
            get => fuelConsumption;
            set => fuelConsumption = 1.25;
        }
        

        public virtual void Drive(double kilometers)
        {
            Fuel -= FuelConsumption * kilometers;
        }
    }
}
