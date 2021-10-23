using ProjectDB;
using ProjectDB.DBModel;

namespace DataRepository
{
    public class RiskRepository : BaseRepository<Risk>,IRiskRepository
    {
        public RiskRepository(ProjectContext projectContext) : base(projectContext)
        {
        }
    }
}