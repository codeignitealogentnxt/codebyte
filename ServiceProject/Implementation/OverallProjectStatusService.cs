using CommonModel;
using DataRepository;
using ProjectDB.DBModel;
using System.Collections.Generic;
using System.Linq;

namespace ServiceProject
{
    public class OverallProjectStatusService : IOverallProjectStatusService
    {
        private IOverallProjectStatusRepository _overallProjectStatusRepository;

        public OverallProjectStatusService(IOverallProjectStatusRepository overallProjectStatusRepository)
        {
            _overallProjectStatusRepository = overallProjectStatusRepository;
        }

        public IEnumerable<OverallProjectStatusModel> GetAll()
        {
            return _overallProjectStatusRepository.GetAll().Select(MapToModel);
        }

        public OverallProjectStatusModel GetByID(int id)
        {
            return MapToModel(_overallProjectStatusRepository.GetById(id));
        }

        public int AddProjectStatus(OverallProjectStatusModel model)
        {
            OverallProjectStatus entity = new OverallProjectStatus()
            {
                Comment = model.Comment,
                Date = model.Date,
                ProjectArea = model.ProjectArea,
                ProjectID = model.ProjectID,
                Status = model.Status
            };
            return _overallProjectStatusRepository.Add(entity);
        }

        public int Delete(int id)
        {
            return _overallProjectStatusRepository.Delete(id);
        }

        private OverallProjectStatusModel MapToModel(OverallProjectStatus overallProjectStatus)
        {
            return new OverallProjectStatusModel
            {
                Comment = overallProjectStatus.Comment,
                Date = overallProjectStatus.Date,
                ProjectArea = overallProjectStatus.ProjectArea,
                ProjectID = overallProjectStatus.ProjectID,
                Status = overallProjectStatus.Status
            };
        }
    }
}