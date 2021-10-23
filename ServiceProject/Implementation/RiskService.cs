using CommonModel;
using DataRepository;
using ProjectDB.DBModel;
using System.Collections.Generic;
using System.Linq;

namespace ServiceProject
{
    public class RiskService : IRiskService
    {
        private IRiskRepository _riskRepository;

        public RiskService(IRiskRepository riskRepository)
        {
            _riskRepository = riskRepository;
        }

        public IEnumerable<RiskModel> GetAllRisks()
        {
            return _riskRepository.GetAll().Select(MapToModel);
        }

        public RiskModel GetRiskByID(int id)
        {
            return MapToModel(_riskRepository.GetById(id));
        }

        public int AddRisk(RiskModel model)
        {
            Risk entity = new Risk()
            {
                ClosedDate = model.ClosedDate,
                Description = model.Description,
                IdentfiedDate = model.IdentfiedDate,
                Mitigation = model.Mitigation,
                ProjectID = model.ProjectID,
                Severity = model.Severity
            };
            return _riskRepository.Add(entity);
        }

        public int Delete(int id)
        {
            return _riskRepository.Delete(id);
        }

        private RiskModel MapToModel(Risk enity)
        {
            return new RiskModel
            {
                ClosedDate = enity.ClosedDate,
                Description = enity.Description,
                IdentfiedDate = enity.IdentfiedDate,
                Mitigation = enity.Mitigation,
                ProjectID = enity.ProjectID,
                Severity = enity.Severity
            };
        }
    }
}