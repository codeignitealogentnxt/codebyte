using CommonModel;
using Microsoft.AspNetCore.Mvc;
using ServiceProject;
using System.Collections.Generic;

namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiskController : ControllerBase
    {
        private IRiskService _riskService;

        public RiskController(IRiskService riskService)
        {
            _riskService = riskService;
        }

        // GET: api/<OverallProjectStatusController>
        [HttpGet]
        public IEnumerable<RiskModel> Get()
        {
            return _riskService.GetAllRisks();
        }

        // GET api/<OverallProjectStatusController>/5
        [HttpGet("{id}")]
        public RiskModel Get(int id)
        {
            return _riskService.GetRiskByID(id);
        }

        // POST api/<OverallProjectStatusController>
        [HttpPost]
        public RiskResponse Post([FromBody] RiskModel model)
        {
            if (_riskService.AddRisk(model) > 0)
            {
                return new RiskResponse { Success = true };
            }
            var result = new RiskResponse { Success = false };
            result.Errors.Add("Cannot add the risk.");
            return result;
        }

        // DELETE api/<OverallProjectStatusController>/5
        [HttpDelete("{id}")]
        public RiskResponse Delete(int id)
        {
            if (_riskService.Delete(id) > 0)
            {
                return new RiskResponse { Success = true };
            }
            var result = new RiskResponse { Success = false };
            result.Errors.Add("Cannot delete risk.");
            return result;
        }
    }
}