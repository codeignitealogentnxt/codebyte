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

        [Route("Upload")]
        [HttpPost(nameof(Upload))]
        public IActionResult Upload()
        {
            try
            {
                var files = Enumerable.Range(0, Request.Form.Files.Count);
                //.Select(f => Request.Form.Files[f]).ToList();
                //string subDirectory = "UploadedFiles";
                //_fileService.UploadFile(files, subDirectory);
                return Ok();
                //new { files.Count, Size = _fileService.SizeConverter(files.Sum(f => f.Length)) }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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