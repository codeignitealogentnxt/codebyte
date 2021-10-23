using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonModel;
using Microsoft.AspNetCore.Mvc;
using ServiceProject;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IProjectUpdateService _projectUpdateService;
        private readonly IProjectMilestoneService _projectMilestoneService;

        public ProjectController(IProjectService projectService , IProjectMilestoneService projectMilestoneService,
            IProjectUpdateService projectUpdateService)
        {
            this._projectService = projectService;
            this._projectUpdateService = projectUpdateService;
            this._projectMilestoneService = projectMilestoneService;
        }


        // POST api/<ProjectController>
        [Route("getAll")]
        [HttpGet]
        public IActionResult GetALL()
        {
            var response = _projectService.GetProjects();
            return Ok(response);
        }

        // POST api/<ProjectController>
        [Route("add")]
        [HttpPost]
        public IActionResult Add([FromBody] ProjectModel model)
        {
            var response = _projectService.AddProject(model);

            return Ok(response);
        }

        // POST api/<ProjectController>
        [Route("updates")]
        [HttpPost]
        public IActionResult Updates([FromBody] ProjectUpdateModel model)
        {
            var response = _projectUpdateService.AddProjectUpdate(model);
            return Ok(response);
        }

        // POST api/<ProjectController>
        [Route("milestone")]
        [HttpPost]
        public IActionResult MileStone([FromBody] ProjectMilestoneModel model)
        {
            var response = _projectMilestoneService.AddProjectMilestone(model);
            return Ok(response);
        }

    }
}
