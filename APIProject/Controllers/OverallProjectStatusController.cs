using CommonModel;
using Microsoft.AspNetCore.Mvc;
using ServiceProject;
using System.Collections.Generic;

namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OverallProjectStatusController : ControllerBase
    {
        private IOverallProjectStatusService _overallProjectStatusService;

        public OverallProjectStatusController(IOverallProjectStatusService overallProjectStatusService)
        {
            _overallProjectStatusService = overallProjectStatusService;
        }

        // GET: api/<OverallProjectStatusController>
        [HttpGet]
        public IEnumerable<OverallProjectStatusModel> Get()
        {
            return _overallProjectStatusService.GetAll();
        }

        // GET api/<OverallProjectStatusController>/5
        [HttpGet("{id}")]
        public OverallProjectStatusModel Get(int id)
        {
            return _overallProjectStatusService.GetByID(id);
        }

        // POST api/<OverallProjectStatusController>
        [HttpPost]
        public OverallProjectStatusResponse Post([FromBody] OverallProjectStatusModel model)
        {
            if (_overallProjectStatusService.AddProjectStatus(model) > 0)
            {
                return new OverallProjectStatusResponse { Success = true };
            }
            var result = new OverallProjectStatusResponse { Success = false };
            result.Errors.Add("Cannot add the overall project status.");
            return result;
        }

        // DELETE api/<OverallProjectStatusController>/5
        [HttpDelete("{id}")]
        public OverallProjectStatusResponse Delete(int id)
        {
            if (_overallProjectStatusService.Delete(id) > 0)
            {
                return new OverallProjectStatusResponse { Success = true };
            }
            var result = new OverallProjectStatusResponse { Success = false };
            result.Errors.Add("Cannot delete overall project status.");
            return result;
        }
    }
}