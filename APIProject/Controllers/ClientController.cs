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
    public class ClientController : ControllerBase
    {
        private IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // POST api/<ClientController>
        [Route("add")]
        [HttpPost]
        public IActionResult Add([FromBody] ClientModel clientModel)
        {
            var result = _clientService.AddClient(clientModel);
            return Ok(result);
        }

        [Route("countries")]
        [HttpGet]
        public IActionResult GetCountries()
        {
            var result = _clientService.GetCountries();
            return Ok(result);
        }

        [Route("getallclient")]
        [HttpGet]
        public IActionResult GetAllClient()
        {
            var result = _clientService.GetClients();
            return Ok(result);
        }

    }
}