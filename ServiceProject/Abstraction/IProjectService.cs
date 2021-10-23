using CommonModel;
using ProjectDB.DBModel;
using System.Collections.Generic;

namespace ServiceProject
{
    public interface IProjectService
    {
        bool AddProject(ProjectModel model);
        IEnumerable<ProjectModel> GetProjects();
        IEnumerable<ProjectModel> GetProjectByClient(int clientId);
        ProjectModel GetProject(int projectId);
    }
}
