﻿using Microsoft.AspNetCore.Mvc;
using ProjectDB.DBModel;
using ServiceProject.Abstraction;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeSearchController : ControllerBase
    {
        private IJobDescriptionService _jobDescriptionService;
        public ResumeSearchController(IJobDescriptionService service)
        {
            _jobDescriptionService = service;
        }

        [HttpGet]
        public IActionResult GetResumeMatches(int jobDescriptionId)
        {
            //var result = _clientService.GetCountries();
            //return Ok(result);
            return null;
        }

    }
}