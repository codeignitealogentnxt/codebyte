using ProjectDB;
using ProjectDB.DBModel;
using System.Collections.Generic;
using System.Linq;

namespace DataRepository
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectContext _dbContext { get; }

        public ProjectRepository(ProjectContext projectContext) : base(projectContext)
        {
            _dbContext = projectContext;
        }

        public IEnumerable<Project> GetProjectsByClient(int clientId)
        {
            return _dbContext.Set<Project>().Where(x => x.ClientId == clientId);
        }
    }
}