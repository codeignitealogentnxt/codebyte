using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceProject;

namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkAccomplishedController : ControllerBase
    {
        private IWorkAccomplishedService _workAccomplishedService;

        public WorkAccomplishedController(IWorkAccomplishedService workAccomplishedService)
        {
            _workAccomplishedService = workAccomplishedService;
        }

        // GET: api/<OverallProjectStatusController>
        [HttpGet]
        public IEnumerable<WorkAccomplishedModel> Get()
        {
            return _workAccomplishedService.GetAllWorksAccomplished();
        }

        // GET api/<OverallProjectStatusController>/5
        [HttpGet("{id}")]
        public WorkAccomplishedModel Get(int id)
        {
            return _workAccomplishedService.GetWorkAccomplishedByID(id);
        }

        // POST api/<OverallProjectStatusController>
        [HttpPost]
        public WorkAccomplishedResponse Post([FromBody] WorkAccomplishedModel model)
        {
            if (_workAccomplishedService.AddWorkAccomplished(model) > 0)
            {
                return new WorkAccomplishedResponse { Success = true };
            }
            var result = new WorkAccomplishedResponse { Success = false };
            result.Errors.Add("Cannot add work accomplished.");
            return result;
        }

        // DELETE api/<OverallProjectStatusController>/5
        [HttpDelete("{id}")]
        public WorkAccomplishedResponse Delete(int id)
        {
            if (_workAccomplishedService.Delete(id) > 0)
            {
                return new WorkAccomplishedResponse { Success = true };
            }
            var result = new WorkAccomplishedResponse { Success = false };
            result.Errors.Add("Cannot delete work accomplished.");
            return result;
        }
    }
}
