namespace NeedForSpeed
{
    public class SportCar : Car
    {
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption 
        { 
            set => base.FuelConsumption = 10;
        }

        public override void Drive(double kilometers)
        {
            Fuel -= FuelConsumption * kilometers;
        }
    }
}
