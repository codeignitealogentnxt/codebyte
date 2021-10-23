using ProjectDB;
using ProjectDB.DBModel;

namespace DataRepository
{
    public class ProjectUpdateRepository : BaseRepository<ProjectUpdate>,IProjectUpdateRepository
    {
        public ProjectUpdateRepository(ProjectContext projectContext) : base(projectContext)
        {
        }
    }
}