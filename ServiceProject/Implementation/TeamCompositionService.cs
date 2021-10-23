using CommonModel;
using DataRepository;
using ProjectDB.DBModel;
using System.Collections.Generic;
using System.Linq;

namespace ServiceProject
{
    public class TeamCompositionService : ITeamCompositionService
    {
        private ITeamCompositionRepository _teamCompositionRepository;

        public TeamCompositionService(ITeamCompositionRepository teamCompositionRepository)
        {
            _teamCompositionRepository = teamCompositionRepository;
        }

        public IEnumerable<TeamCompositionModel> GetAllTeamCompositions()
        {
            return _teamCompositionRepository.GetAll().Select(MapToModel);
        }

        public TeamCompositionModel GetTeamcompositionByID(int id)
        {
            return MapToModel(_teamCompositionRepository.GetById(id));
        }

        public int AddTeamComposition(TeamCompositionModel model)
        {
            TeamComposition entity = new TeamComposition()
            {
                Allocation = model.Allocation,
                BillingEndDate = model.BillingEndDate,
                BillingStartDate = model.BillingStartDate,
                EndDate = model.EndDate,
                ProjectID = model.ProjectID,
                StartDate = model.StartDate
            };
            return _teamCompositionRepository.Add(entity);
        }

        public int Delete(int id)
        {
            return _teamCompositionRepository.Delete(id);
        }

        private TeamCompositionModel MapToModel(TeamComposition enity)
        {
            return new TeamCompositionModel
            {
                Allocation = enity.Allocation,
                BillingEndDate = enity.BillingEndDate,
                BillingStartDate = enity.BillingStartDate,
                EndDate = enity.EndDate,
                ProjectID = enity.ProjectID,
                StartDate = enity.StartDate
            };
        }
    }
}