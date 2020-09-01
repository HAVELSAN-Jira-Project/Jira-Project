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




        [HttpGet("GetBugs")]
        public IActionResult GetBugs()
        {
            try
            {
                List<ListIssuesViewModel> AllBugs = _bugService.ListBugs();

                GetIssuesModel getbugsModel = new GetIssuesModel
                {
                    Issues = AllBugs,
                    IssueCount = AllBugs.Count,
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



        [HttpGet("GetBugsFilterbyDate")]
        public IActionResult GetBugsFilterbyDate(int days)
        {

            //BUSINESSA ERİŞİP DÖNEN VERİYİ DİREK MODELE SETLEYİP DÖNDER. GELEN VERİNİN KONTROLÜ BUSINESSDA
                var BugsbyDate = _bugService.ListBugsFilterbyDate(days);

                GetIssuesModel getBugsModel = new GetIssuesModel
                {
                    Issues = BugsbyDate,
                    IssueCount = BugsbyDate.Count,
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

            GetIssuesModel getBugsModel = new GetIssuesModel
            {
                Issues = BugsbySeverity,
                IssueCount = BugsbySeverity.Count,
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

                GetIssuesModel getBugsModel = new GetIssuesModel
                {
                    Issues = SearchedBugs,
                    IssueCount = SearchedBugs.Count,
                    ProjectKey = JiraRequestManager.ProjectKey,
                    TotalRebound = SearchedBugs.Sum(x => x.Rebound)
                };

                return Ok(getBugsModel);


            

        }
    }
}
