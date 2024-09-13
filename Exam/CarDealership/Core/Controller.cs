using System.Text;
using CarDealership.Core.Contracts;
using CarDealership.Models;
using CarDealership.Models.Contracts;
using CarDealership.Utilities.Messages;

namespace CarDealership.Core
{
    public class Controller : IController
    {
        private IDealership dealership;

        public Controller()
        {
            dealership = new Dealership();
        }

        public string AddCustomer(string customerTypeName, string customerName)
        {
            if (customerTypeName != nameof(IndividualClient) 
                && customerTypeName != nameof(LegalEntityCustomer))
            {
                return string.Format(OutputMessages.InvalidType, customerTypeName);
            }

            if (dealership.Customers.Get(customerName) != null)
            {
                return string.Format(OutputMessages.CustomerAlreadyAdded, customerName);
            }

            ICustomer customer;
            if (customerTypeName == nameof(IndividualClient))
            {
                customer = new IndividualClient(customerName);
            }
            else
            {
                customer = new LegalEntityCustomer(customerName);
            }
            dealership.Customers.Add(customer);

            return string.Format(OutputMessages.CustomerAddedSuccessfully, customerName);
        }

        public string AddVehicle(string vehicleTypeName, string model, double price)
        {
            if (vehicleTypeName != nameof(SaloonCar)
                && vehicleTypeName != nameof(SUV)
                && vehicleTypeName != nameof(Truck))
            {
                return string.Format(OutputMessages.InvalidType, vehicleTypeName);
            }

            if (dealership.Vehicles.Get(model) != null)
            {
                return string.Format(OutputMessages.VehicleAlreadyAdded, model);
            }

            IVehicle vehicle;
            if (vehicleTypeName == nameof(SaloonCar))
            {
                vehicle = new SaloonCar(model, price);
            }
            else if (vehicleTypeName == nameof(SUV))
            {
                vehicle = new SUV(model, price);
            }
            else
            {
                vehicle = new Truck(model, price);
            }

            dealership.Vehicles.Add(vehicle);
            return string.Format(OutputMessages.VehicleAddedSuccessfully, vehicleTypeName, model, vehicle.Price.ToString("f2"));
        }

        public string PurchaseVehicle(string vehicleTypeName, string customerName, double budget)
        {
            if (dealership.Customers.Get(customerName) == null)
            {
                return string.Format(OutputMessages.CustomerNotFound, customerName);
            }

            if (vehicleTypeName != nameof(SaloonCar)
                && vehicleTypeName != nameof(SUV)
                && vehicleTypeName != nameof(Truck))
            {
                return string.Format(OutputMessages.VehicleTypeNotFound, vehicleTypeName);
            }

            ICustomer customer = dealership.Customers.Get(customerName);

            if ((customer.GetType().Name == nameof(IndividualClient)
                && vehicleTypeName == nameof(Truck))
                || (customer.GetType().Name == nameof(LegalEntityCustomer)
                    && vehicleTypeName == nameof(SaloonCar)))
            {
                return string.Format(OutputMessages.CustomerNotEligibleToPurchaseVehicle, customerName,
                    vehicleTypeName);
            }

            IVehicle relevantVehicle = dealership.Vehicles.Models
                .Where(m => m.GetType().Name == vehicleTypeName && budget >= m.Price)
                .OrderByDescending(m => m.Price)
                .FirstOrDefault();

            if (relevantVehicle == null)
            {
                return string.Format(OutputMessages.BudgetIsNotEnough, customerName, vehicleTypeName);
            }

            customer.BuyVehicle(relevantVehicle.Model);
            relevantVehicle.SellVehicle(customerName);
            return string.Format(OutputMessages.VehiclePurchasedSuccessfully, customerName, relevantVehicle.Model);
        }

        public string CustomerReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Customer Report:");
            List<ICustomer> customers = dealership.Customers.Models
                .OrderBy(m => m.Name)
                .ToList();

            foreach (ICustomer customer in customers)
            {
                sb.AppendLine(customer.ToString());
                sb.AppendLine("-Models:");

                if (customer.Purchases.Count == 0)
                {
                    sb.AppendLine("--none");
                    continue;
                }

                List<string> purchasedVehicles = customer.Purchases
                    .OrderBy(m => m)
                    .ToList();
                foreach (string purchasedVehicle in purchasedVehicles)
                {
                    sb.AppendLine($"--{purchasedVehicle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string SalesReport(string vehicleTypeName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{vehicleTypeName} Sales Report:");

            List<IVehicle> vehicles = dealership.Vehicles.Models
                .Where(m => m.GetType().Name == vehicleTypeName)
                .OrderBy(m => m.Model)
                .ToList();
            int totalCountSoldFromType = 0;

            foreach (IVehicle vehicle in vehicles)
            {
                sb.AppendLine($"--{vehicle.ToString()}");
                totalCountSoldFromType += vehicle.SalesCount;
            }

            sb.AppendLine($"-Total Purchases: {totalCountSoldFromType}");

            return sb.ToString().TrimEnd();
        }
    }
}
