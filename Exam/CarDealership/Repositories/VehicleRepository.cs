using CarDealership.Models.Contracts;
using CarDealership.Repositories.Contracts;

namespace CarDealership.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        private List<IVehicle> models;

        public VehicleRepository()
        {
            models = new List<IVehicle>();
        }

        public IReadOnlyCollection<IVehicle> Models
        {
            get => models.AsReadOnly();
        }

        public void Add(IVehicle model)
        {
            models.Add(model);
        }

        public bool Remove(string text)
        {
            IVehicle model = models.FirstOrDefault(m => m.Model == text);
            if (model == null)
            {
                return false;
            }

            models.Remove(model);
            return true;
        }

        public bool Exists(string text)
        {
            IVehicle model = models.FirstOrDefault(m => m.Model == text);
            if (model == null)
            {
                return false;
            }

            return true;
        }

        public IVehicle Get(string text)
        {
            IVehicle model = models.FirstOrDefault(m => m.Model == text);
            return model;
        }
    }
}
