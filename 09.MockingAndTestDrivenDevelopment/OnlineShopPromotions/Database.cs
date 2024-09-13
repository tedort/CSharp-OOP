using Newtonsoft.Json;

namespace OnlineShopPromotions
{
    public class Database<T> : IDatabase<T>
    {
        private string path = "../../../db.txt";
        public List<T> GetAll()
        {
            if (!File.Exists(path))
            {
                return new List<T>();
            }

            using (StreamReader reader = new StreamReader(path))
            {
                return JsonConvert.DeserializeObject<List<T>>(reader.ReadToEnd());
            }
        }

        public void Save(List<T> products)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine(JsonConvert.SerializeObject(products, Formatting.Indented));
            }
        }
    }
}
