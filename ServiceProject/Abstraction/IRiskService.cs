using CommonModel;
using System.Collections.Generic;

namespace ServiceProject
{
    public interface IRiskService
    {
        IEnumerable<RiskModel> GetAllRisks();

        RiskModel GetRiskByID(int id);

        int AddRisk(RiskModel model);

        int Delete(int id);
    }
}