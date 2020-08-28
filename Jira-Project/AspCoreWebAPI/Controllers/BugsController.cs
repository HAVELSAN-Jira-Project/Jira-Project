using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCoreWebAPI.Models;
using Business.Abstract;
using Business.Concrete;
using Business.JiraDeserializeModels.Bugs;
using DataAccess.ViewModels;
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
        public IActionResult GetBugs()
        {
            try
            {
                List<ListBugsViewModel> AllBugs = _bugService.ListBugs();

                GetBugsModel getbugsModel = new GetBugsModel
                {
                    Bugs = AllBugs,
                    BugCount = AllBugs.Count,
                    ProjectKey = JiraRequestManager.ProjectKey,
                    TotalRebound = AllBugs.Sum(x => x.Rebound) //PROJEDEKİ TOPLAM REBOUND SAYISI
                };
                return Ok(getbugsModel); //MODELİ DÖNDÜR
            }
            catch
            {
                return BadRequest("Buglar Listelenemedi.");
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


        [HttpGet("GetBugsFilterbyDate")]
        public IActionResult GetBugsFilterbyDate(int days)
        {

                //BUSINESSA ERİŞİP DÖNEN VERİYİ DİREK MODELE SETLEYİP DÖNDER. GELEN VERİNİN KONTROLÜ BUSINESSDA
                 var BugsbyDate = _bugService.ListBugsFilterbyDate(days);

                GetBugsModel getBugsModel = new GetBugsModel
                {
                    Bugs = BugsbyDate,
                    BugCount = BugsbyDate.Count,
                    ProjectKey = JiraRequestManager.ProjectKey,
                    TotalRebound = BugsbyDate.Sum(x => x.Rebound)
                };

                return Ok(getBugsModel);  //MODELİ DÖN
                
        }


        [HttpGet("GetBugsFilterbySeverity")]
        public IActionResult GetBugsFilterbySeverity(int severity)
        {

            //BUSINESSA ERİŞİP DÖNEN VERİYİ DİREK MODELE SETLEYİP DÖNDER. GELEN VERİNİN KONTROLÜ BUSINESSDA
            var BugsbySeverity = _bugService.ListBugsFilterbySeverity(severity);

            GetBugsModel getBugsModel = new GetBugsModel
            {
                Bugs = BugsbySeverity,
                BugCount = BugsbySeverity.Count,
                ProjectKey = JiraRequestManager.ProjectKey,
                TotalRebound = BugsbySeverity.Sum(x => x.Rebound)
            };

            return Ok(getBugsModel);
        }



        [HttpGet("GetSearchedBugs")]
        public IActionResult GetSearchedBugs(string text)
        {

            //BUSINESSA ERİŞİP DÖNEN VERİYİ DİREK MODELE SETLEYİP DÖNDER. GELEN VERİNİN KONTROLÜ BUSINESSDA
            var SearchedBugs = _bugService.ListSearchedBugs(text);

                GetBugsModel getBugsModel = new GetBugsModel
                {
                    Bugs = SearchedBugs,
                    BugCount = SearchedBugs.Count,
                    ProjectKey = JiraRequestManager.ProjectKey,
                    TotalRebound = SearchedBugs.Sum(x => x.Rebound)
                };

                return Ok(getBugsModel);


            

        }
    }
}
