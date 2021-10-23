using ProjectDB;
using ProjectDB.DBModel;

namespace DataRepository
{
    public class OverallProjectStatusRepository : BaseRepository<OverallProjectStatus>, IOverallProjectStatusRepository
    {
        public OverallProjectStatusRepository(ProjectContext projectContext) : base(projectContext)
        {
        }
    }
}