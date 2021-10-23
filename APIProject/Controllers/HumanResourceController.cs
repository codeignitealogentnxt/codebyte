using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanResourceController : ControllerBase
    {


        #region Property  
        //private readonly IFileService _fileService;
        #endregion
        #region Constructor  
        public HumanResourceController()
        {
            //
        }
        #endregion
        #region Upload  
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
        #endregion
    }
}
