using CommonModel;
using System.Collections.Generic;

namespace ServiceProject
{
    public interface IProjectUpdateService
    {
        IEnumerable<ProjectUpdateModel> GetAllProjectUpdates();

        ProjectUpdateModel GetProjectUpdateByID(int id);

        int AddProjectUpdate(ProjectUpdateModel model);

        int Delete(int id);
    }
}