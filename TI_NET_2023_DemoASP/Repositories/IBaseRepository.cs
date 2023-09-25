namespace TI_NET_2023_DemoASP.Repositories
{
    public interface IBaseRepository<TKey, TEntity> where TEntity : class
    {
        TEntity Create(TEntity entity);
        TEntity ReadOne(TKey id);
        IEnumerable<TEntity> ReadAll();
        bool Update(TKey id, TEntity entity);
        bool Delete(TKey id);
    }
}
