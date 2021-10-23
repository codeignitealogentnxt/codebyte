using System.Collections.Generic;

namespace DataRepository
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        int Delete(int id);

        int Add(T entity);
    }
}