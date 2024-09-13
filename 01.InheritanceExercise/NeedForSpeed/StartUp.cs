using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SportCar sportCar = new SportCar(300, 40);
            sportCar.Drive(5);
            RaceMotorcycle raceMotorcycle = new RaceMotorcycle(150, 25);
            raceMotorcycle.Drive(5);
            Car car = new Car(200, 35);
            car.Drive(5);
            Vehicle vehicle = new Vehicle(100, 10);
            vehicle.Drive(5);
            Console.WriteLine(sportCar.Fuel);
            Console.WriteLine(raceMotorcycle.Fuel);
            Console.WriteLine(car.Fuel);
            Console.WriteLine(vehicle.Fuel);
        }
    }
}
