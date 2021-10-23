using ProjectDB;
using ProjectDB.DBModel;

namespace DataRepository
{
    public class WorkAccomplishedRepository : BaseRepository<WorkAccomplished>,IWorkAccomplishedRepository
    {
        public WorkAccomplishedRepository(ProjectContext projectContext) : base(projectContext)
        {
        }
    }
}