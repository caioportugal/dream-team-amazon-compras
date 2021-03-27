namespace Amazon.Purchases.Database.Repository
{
    public interface IRepository<TEntity> where TEntity: class
    {
        TEntity Get(int id);
        void Add(TEntity entity);
    }
}