using CommonModel;
using System.Collections.Generic;

namespace ServiceProject
{
    public interface IWorkAccomplishedService
    {
        IEnumerable<WorkAccomplishedModel> GetAllWorksAccomplished();

        WorkAccomplishedModel GetWorkAccomplishedByID(int id);

        int AddWorkAccomplished(WorkAccomplishedModel model);

        int Delete(int id);
    }
}