using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugController : ControllerBase
    {

        private readonly IBugService _bugService;

        public BugController(IBugService bugService)
        {
            _bugService = bugService;
        }



        [HttpGet("AddBugs")]
        public IActionResult AddBugs()
        {
            bool result = _bugService.AddBugs();

            if (result)
                return Ok("Buglar Başarıyla Veritabanına Eklendi.");
            else
                return BadRequest("Buglar Veritabanına Eklenemedi.");

        }


        [HttpGet("GetBugs")]
        public IActionResult GetBugs()
        {
            try
            {
                return Ok(_bugService.ListBugs());
            }
            catch
            {
                return BadRequest("Loglar Listelenemedi.");
            }
        }
    }
}
