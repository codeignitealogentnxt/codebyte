using CommonModel;
using CommonModel.Enum;
using DataRepository;
using ProjectDB.DBModel;
using System.Collections.Generic;
using System.Linq;

namespace ServiceProject
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public bool AddProject(ProjectModel model)
        {
            return _projectRepository.Add(ConvertToEnityProject(model)) > 0;
        }

        public IEnumerable<ProjectModel> GetProjectByClient(int clientId)
        {
            return _projectRepository.GetProjectsByClient(clientId).Select(x=> MapToModel(x));
        }

        public IEnumerable<ProjectModel> GetProjects()
        {
            return _projectRepository.GetAll().Select(x => MapToModel(x));
        }

        public ProjectModel GetProject(int projectId)
        {
            var project = _projectRepository.GetById(projectId);
            return MapToModel(project);
        }


        private ProjectModel MapToModel(Project enity)
        {
            return new ProjectModel()
            {
                AccountManagerEmail = enity.AccountManagerEmail,
                BilledResourceCount = enity.BilledResourceCount,
                ClientId = enity.ClientId,
                ClientManagerEmail = enity.ClientManagerEmail,
                Code = enity.Code,
                Name = enity.Name,
                ProjectManagerEmail = enity.ProjectManagerEmail,
                ProjectStatus = enity.ProjectStatus,
                ReosurceCount = enity.ReosurceCount,
            };
        }

        private Project ConvertToEnityProject(ProjectModel model)
        {
            return new Project()
            {
               AccountManagerEmail = model.AccountManagerEmail,
               BilledResourceCount = model.BilledResourceCount,
               ClientId = model.ClientId,
               ClientManagerEmail = model.ClientManagerEmail,
               Code = model.Code,
               Name = model.Name,
               ProjectManagerEmail = model.ProjectManagerEmail,
               ProjectStatus = Status.New,
               ReosurceCount = model.ReosurceCount
            };
        }

    }
}