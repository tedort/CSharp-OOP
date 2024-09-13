using Vehicles.Models;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carTokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Car car = new Car(double.Parse(carTokens[1]), double.Parse(carTokens[2]), double.Parse(carTokens[3]));

            string[] truckTokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Truck truck = new Truck(double.Parse(truckTokens[1]), double.Parse(truckTokens[2]), double.Parse(truckTokens[3]));


            string[] busTokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Bus bus = new Bus(double.Parse(busTokens[1]), double.Parse(busTokens[2]), double.Parse(busTokens[3]));

            int commands = int.Parse(Console.ReadLine());

            for (int i = 0; i < commands; i++)
            {
                try
                {
                    string[] data = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    if (data[0] == "Drive")
                    {
                        switch (data[1])
                        {
                            case "Car":
                                car.Drive(double.Parse(data[2]));
                                break;

                            case "Truck":
                                truck.Drive(double.Parse(data[2]));
                                break;

                            case "Bus":
                                bus.DriveWithPeople(double.Parse(data[2]));
                                break;
                        }
                    }
                    else if (data[0] == "Refuel")
                    {
                        switch (data[1])
                        {
                            case "Car":
                                car.Refuel(double.Parse(data[2]));
                                break;

                            case "Truck":
                                truck.Refuel(double.Parse(data[2]));
                                break;

                            case "Bus":
                                bus.Refuel(double.Parse(data[2]));
                                break;
                        }
                    }
                    else if (data[0] == "DriveEmpty")
                    {
                        bus.Drive(double.Parse(data[2]));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
