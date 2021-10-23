using ProjectDB.DBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository
{
    public interface IProjectRepository:IBaseRepository<Project>
    {
        IEnumerable<Project> GetProjectsByClient(int clientId);
    }
}
