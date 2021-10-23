using CommonModel;
using DataRepository;
using ProjectDB.DBModel;
using System.Collections.Generic;
using System.Linq;

namespace ServiceProject
{
    public class ProjectMilestoneService : IProjectMilestoneService
    {
        private IProjectMilestoneRepository _projectMilestoneRepository;

        public ProjectMilestoneService(IProjectMilestoneRepository projectMilestoneRepository)
        {
            _projectMilestoneRepository = projectMilestoneRepository;
        }

        public IEnumerable<ProjectMilestoneModel> GetAllProjectMilestones()
        {
            return _projectMilestoneRepository.GetAll().Select(MapToModel);
        }

        public ProjectMilestoneModel GetProjectMilestoneByID(int id)
        {
            return MapToModel(_projectMilestoneRepository.GetById(id));
        }

        public int AddProjectMilestone(ProjectMilestoneModel model)
        {
            ProjectMilestone entity = new ProjectMilestone()
            {
                ActualDate = model.ActualDate,
                Comment = model.Comment,
                MilestoneName = model.MilestoneName,
                PlannedDate = model.PlannedDate,
                ProjectID = model.ProjectID
            };
            return _projectMilestoneRepository.Add(entity);
        }

        public int Delete(int id)
        {
            return _projectMilestoneRepository.Delete(id);
        }

        private ProjectMilestoneModel MapToModel(ProjectMilestone enity)
        {
            return new ProjectMilestoneModel
            {
                ActualDate = enity.ActualDate,
                Comment = enity.Comment,
                MilestoneName = enity.MilestoneName,
                PlannedDate = enity.PlannedDate,
                ProjectID = enity.ProjectID
            };
        }
    }
}