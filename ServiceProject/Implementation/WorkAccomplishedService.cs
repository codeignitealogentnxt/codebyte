using CommonModel;
using DataRepository;
using ProjectDB.DBModel;
using System.Collections.Generic;
using System.Linq;

namespace ServiceProject
{
    public class WorkAccomplishedService : IWorkAccomplishedService
    {
        private IWorkAccomplishedRepository _workAccomplishedRepository;

        public WorkAccomplishedService(IWorkAccomplishedRepository workAccomplishedRepository)
        {
            _workAccomplishedRepository = workAccomplishedRepository;
        }

        public IEnumerable<WorkAccomplishedModel> GetAllWorksAccomplished()
        {
            return _workAccomplishedRepository.GetAll().Select(MapToModel);
        }

        public WorkAccomplishedModel GetWorkAccomplishedByID(int id)
        {
            return MapToModel(_workAccomplishedRepository.GetById(id));
        }

        public int AddWorkAccomplished(WorkAccomplishedModel model)
        {
            WorkAccomplished entity = new WorkAccomplished()
            {
                Comment = model.Comment,
                EndDate = model.EndDate,
                ProjectID = model.ProjectID,
                StartDate = model.StartDate,
                WorkAccomplishedDetails = model.WorkAccomplishedDetails
            };
            return _workAccomplishedRepository.Add(entity);
        }

        public int Delete(int id)
        {
            return _workAccomplishedRepository.Delete(id);
        }

        private WorkAccomplishedModel MapToModel(WorkAccomplished enity)
        {
            return new WorkAccomplishedModel
            {
                Comment = enity.Comment,
                EndDate = enity.EndDate,
                ProjectID = enity.ProjectID,
                StartDate = enity.StartDate,
                WorkAccomplishedDetails = enity.WorkAccomplishedDetails
            };
        }
    }
}