using CommonModel;
using DataRepository;
using ProjectDB.DBModel;
using System.Collections.Generic;
using System.Linq;

namespace ServiceProject
{
    public class ProjectUpdateService : IProjectUpdateService
    {
        private IProjectUpdateRepository _projectUpdateRepository;

        public ProjectUpdateService(IProjectUpdateRepository projectUpdateRepository)
        {
            _projectUpdateRepository = projectUpdateRepository;
        }

        public IEnumerable<ProjectUpdateModel> GetAllProjectUpdates()
        {
            return _projectUpdateRepository.GetAll().Select(MapToModel);
        }

        public ProjectUpdateModel GetProjectUpdateByID(int id)
        {
            return MapToModel(_projectUpdateRepository.GetById(id));
        }

        public int AddProjectUpdate(ProjectUpdateModel model)
        {
            ProjectUpdate entity = new ProjectUpdate()
            {
                Comment = model.Comment,
                Date = model.Date,
                ProjectID = model.ProjectID,
                UpdateType = model.UpdateType
            };
            return _projectUpdateRepository.Add(entity);
        }

        public int Delete(int id)
        {
            return _projectUpdateRepository.Delete(id);
        }

        private ProjectUpdateModel MapToModel(ProjectUpdate enity)
        {
            return new ProjectUpdateModel
            {
                Comment = enity.Comment,
                Date = enity.Date,
                ProjectID = enity.ProjectID,
                UpdateType = enity.UpdateType
            };
        }
    }
}