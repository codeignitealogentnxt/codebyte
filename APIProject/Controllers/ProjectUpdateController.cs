using CommonModel;
using Microsoft.AspNetCore.Mvc;
using ServiceProject;
using System.Collections.Generic;

namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectUpdateController : ControllerBase
    {
        private IProjectUpdateService _projectUpdateService;

        public ProjectUpdateController(IProjectUpdateService projectUpdateService)
        {
            _projectUpdateService = projectUpdateService;
        }

        // GET: api/<OverallProjectStatusController>
        [HttpGet]
        public IEnumerable<ProjectUpdateModel> Get()
        {
            return _projectUpdateService.GetAllProjectUpdates();
        }

        // GET api/<OverallProjectStatusController>/5
        [HttpGet("{id}")]
        public ProjectUpdateModel Get(int id)
        {
            return _projectUpdateService.GetProjectUpdateByID(id);
        }

        // POST api/<OverallProjectStatusController>
        [HttpPost]
        public ProjectUpdateResponse Post([FromBody] ProjectUpdateModel model)
        {
            if (_projectUpdateService.AddProjectUpdate(model) > 0)
            {
                return new ProjectUpdateResponse { Success = true };
            }
            var result = new ProjectUpdateResponse { Success = false };
            result.Errors.Add("Cannot add the project update.");
            return result;
        }

        // DELETE api/<OverallProjectStatusController>/5
        [HttpDelete("{id}")]
        public ProjectUpdateResponse Delete(int id)
        {
            if (_projectUpdateService.Delete(id) > 0)
            {
                return new ProjectUpdateResponse { Success = true };
            }
            var result = new ProjectUpdateResponse { Success = false };
            result.Errors.Add("Cannot delete project update.");
            return result;
        }
    }
}