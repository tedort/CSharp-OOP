namespace OnlineShopPromotions
{
    public interface IDatabase<T>
    {
        public List<T> GetAll();
        public void Save(List<T> entities);
    }
}
