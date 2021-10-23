using ProjectDB;
using ProjectDB.DBModel;
using System.Collections.Generic;
using System.Linq;

namespace DataRepository
{
    public class BaseRepository<T>:IBaseRepository<T> where T : class
    {
        public ProjectContext DbContext { get; }

        public BaseRepository(ProjectContext projectContext)
        {
            DbContext = projectContext;
        }

        public IEnumerable<T> GetAll()
        {
            return DbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return DbContext.Set<T>().FirstOrDefault(x => (x as AuditableEntity).ID == id);
        }

        public int Delete(int id)
        {
            DbContext.Set<T>().Remove(GetById(id));
            return DbContext.SaveChanges();
        }

        public int Add(T entity)
        {
            DbContext.Set<T>().Add(entity);
            return DbContext.SaveChanges();
        }
    }
}