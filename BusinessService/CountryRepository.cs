using ProjectDB;
using ProjectDB.DBModel;

namespace DataRepository
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(ProjectContext projectContext) : base(projectContext)
        {
        }
    }
}