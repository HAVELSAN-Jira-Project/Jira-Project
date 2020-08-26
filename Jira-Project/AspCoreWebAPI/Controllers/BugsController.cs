using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCoreWebAPI.Models;
using Business.Abstract;
using Business.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugsController : ControllerBase
    {

        private readonly IBugService _bugService;

        public BugsController(IBugService bugService)
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
        public IActionResult GetBugs(){
            try
            {
                GetBugsModel getbugsModel = new GetBugsModel
                {
                    Bugs = _bugService.ListBugs(),
                    BugCount = _bugService.ListBugs().Count,
                    ProjectKey = JiraRequestManager.ProjectKey
                };
                return Ok(getbugsModel);    //MODELİ DÖNDÜR
            }
            catch
            {
                return BadRequest("Loglar Listelenemedi.");
            }
        }



        [HttpGet("ClearBugs")]
        public IActionResult ClearBugs()
        {
            bool result = _bugService.ClearBugs();
            if (result)
                return Ok("Bugs Tablosu Sıfırlandı.");
            else
                return BadRequest("Bugs Tablosu Sıfırlanamadı.");
        }


        [HttpPost("ProjectKey")]
        public IActionResult ProjectKey(ProjectKeyModel projectKeyModel)
        {
            if (ModelState.IsValid)
            {
                JiraRequestManager.ProjectKey = projectKeyModel.ProjectKey;
                return Ok("Proje Numarası Kaydedildi.");
            }
            else
            {
                return BadRequest("Proje Numarası Geçersiz.");
            }
        }
    }
}
