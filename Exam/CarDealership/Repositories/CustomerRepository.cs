using CarDealership.Models.Contracts;
using CarDealership.Repositories.Contracts;

namespace CarDealership.Repositories
{
    public class CustomerRepository : IRepository<ICustomer>
    {
        private List<ICustomer> models;

        public CustomerRepository()
        {
            models = new List<ICustomer>();
        }

        public IReadOnlyCollection<ICustomer> Models
        {
            get => models.AsReadOnly();
        }
        public void Add(ICustomer model)
        {
            models.Add(model);
        }

        public bool Remove(string text)
        {
            ICustomer model = models.FirstOrDefault(m => m.Name == text);
            if (model == null)
            {
                return false;
            }

            models.Remove(model);
            return true;
        }

        public bool Exists(string text)
        {
            ICustomer model = models.FirstOrDefault(m => m.Name == text);
            if (model == null)
            {
                return false;
            }

            return true;
        }

        public ICustomer Get(string text)
        {
            ICustomer model = models.FirstOrDefault(m => m.Name == text);
            return model;
        }
    }
}
