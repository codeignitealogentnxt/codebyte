using ProjectDB;
using ProjectDB.DBModel;
using System.Collections.Generic;

namespace DataRepository
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(ProjectContext projectContext) : base(projectContext)
        {
        }
    }
}