using CommonModel;
using System.Collections.Generic;

namespace ServiceProject
{
    public interface IOverallProjectStatusService
    {
        IEnumerable<OverallProjectStatusModel> GetAll();

        OverallProjectStatusModel GetByID(int id);

        int AddProjectStatus(OverallProjectStatusModel model);

        int Delete(int id);
    }
}