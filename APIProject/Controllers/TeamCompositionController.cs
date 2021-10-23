using CommonModel;
using Microsoft.AspNetCore.Mvc;
using ServiceProject;
using System.Collections.Generic;

namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamCompositionController : ControllerBase
    {
        private ITeamCompositionService _teamCompositionService;

        public TeamCompositionController(ITeamCompositionService teamCompositionService)
        {
            _teamCompositionService = teamCompositionService;
        }

        // GET: api/<OverallProjectStatusController>
        [HttpGet]
        public IEnumerable<TeamCompositionModel> Get()
        {
            return _teamCompositionService.GetAllTeamCompositions();
        }

        // GET api/<OverallProjectStatusController>/5
        [HttpGet("{id}")]
        public TeamCompositionModel Get(int id)
        {
            return _teamCompositionService.GetTeamcompositionByID(id);
        }

        // POST api/<OverallProjectStatusController>
        [HttpPost]
        public TeamCompositionResponse Post([FromBody] TeamCompositionModel model)
        {
            if (_teamCompositionService.AddTeamComposition(model) > 0)
            {
                return new TeamCompositionResponse { Success = true };
            }
            var result = new TeamCompositionResponse { Success = false };
            result.Errors.Add("Cannot add team composition.");
            return result;
        }

        // DELETE api/<OverallProjectStatusController>/5
        [HttpDelete("{id}")]
        public TeamCompositionResponse Delete(int id)
        {
            if (_teamCompositionService.Delete(id) > 0)
            {
                return new TeamCompositionResponse { Success = true };
            }
            var result = new TeamCompositionResponse { Success = false };
            result.Errors.Add("Cannot delete team composition.");
            return result;
        }
    }
}