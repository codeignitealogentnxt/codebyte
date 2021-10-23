using CommonModel;
using System.Collections.Generic;

namespace ServiceProject
{
    public interface ITeamCompositionService
    {
        IEnumerable<TeamCompositionModel> GetAllTeamCompositions();

        TeamCompositionModel GetTeamcompositionByID(int id);

        int AddTeamComposition(TeamCompositionModel model);

        int Delete(int id);
    }
}