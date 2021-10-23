using ProjectDB;
using ProjectDB.DBModel;

namespace DataRepository
{
    public class TeamCompositionRepository : BaseRepository<TeamComposition>,ITeamCompositionRepository
    {
        public TeamCompositionRepository(ProjectContext projectContext) : base(projectContext)
        {
        }
    }
}