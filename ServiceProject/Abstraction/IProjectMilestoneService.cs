using CommonModel;
using System.Collections.Generic;

namespace ServiceProject
{
    public interface IProjectMilestoneService
    {
        IEnumerable<ProjectMilestoneModel> GetAllProjectMilestones();

        ProjectMilestoneModel GetProjectMilestoneByID(int id);

        int AddProjectMilestone(ProjectMilestoneModel model);

        int Delete(int id);
    }
}