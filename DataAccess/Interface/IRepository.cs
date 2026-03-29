using Entities.Interface;


namespace DataAccess.Interface
{
    public interface IRepository<T> where T:IEntity
    {
       bool Create(T entity);
        bool Delete(T entity);
        bool Update(T entity);
        List<T> GetAll(Predicate<T> filter=null);
        T Get(Predicate<T> filter=null);
    }
}
