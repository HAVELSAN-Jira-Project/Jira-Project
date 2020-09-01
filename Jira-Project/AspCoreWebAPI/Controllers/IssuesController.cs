using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCoreWebAPI.Models;
using AspCoreWebAPI.Models.IssueModels;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        private readonly IIssueService _issueService;

        public IssuesController(IIssueService issueService)
        {
            _issueService = issueService;
        }



        [HttpGet("AddIssues")]
        public IActionResult AddIssues()
        {
            bool result = _issueService.AddIssues();

            if (result)
                return Ok("Buglar Başarıyla Veritabanına Eklendi.");
            else
                return BadRequest("Buglar Veritabanına Eklenemedi.");

        }



        [HttpGet("GetIssues")]
        public IActionResult GetIssues()
        {
            try
            {
                List<ListIssuesViewModel> AllIssues = _issueService.ListIssues();

                GetIssuesModel getbugsModel = new GetIssuesModel
                {
                    Issues = AllIssues,
                    IssueCount = AllIssues.Count,
                    ProjectKey = JiraRequestManager.ProjectKey,
                    TotalRebound = AllIssues.Sum(x => x.Rebound) //PROJEDEKİ TOPLAM REBOUND SAYISI
                };
                return Ok(getbugsModel); //MODELİ DÖNDÜR
            }
            catch
            {
                return BadRequest("Buglar Listelenemedi.");
            }
        }



        [HttpGet("ClearIssues")]
        public IActionResult ClearIssues()
        {
            bool result = _issueService.ClearIssues();
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

            return BadRequest("Proje Numarası Geçersiz");

        }



        [HttpPost("IssueType")]
        public IActionResult IssueType(IssueIDModel issueModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("IssueID Geçersiz.");
            }

            JiraRequestManager.IssueTypeID = issueModel.IssueID.Value;
            return Ok("İssueID Başarıyla Değiştirildi.");
        }




        [HttpGet("GetIssuesFilterbyDate")]
        public IActionResult GetIssuesFilterbyDate(int days)
        {

            //BUSINESSA ERİŞİP DÖNEN VERİYİ DİREK MODELE SETLEYİP DÖNDER. GELEN VERİNİN KONTROLÜ BUSINESSDA
            var IssuesbyDate = _issueService.ListIssuesFilterbyDate(days);

            GetIssuesModel getBugsModel = new GetIssuesModel
            {
                Issues = IssuesbyDate,
                IssueCount = IssuesbyDate.Count,
                ProjectKey = JiraRequestManager.ProjectKey,
                TotalRebound = IssuesbyDate.Sum(x => x.Rebound)
            };

            return Ok(getBugsModel);  //MODELİ DÖN

        }



        [HttpGet("GetIssuesFilterbySeverity")]
        public IActionResult GetIssuesFilterbySeverity(int severity)
        {

            //BUSINESSA ERİŞİP DÖNEN VERİYİ DİREK MODELE SETLEYİP DÖNDER. GELEN VERİNİN KONTROLÜ BUSINESSDA
            var IssuesbySeverity = _issueService.ListIssuesFilterbySeverity(severity);

            GetIssuesModel getBugsModel = new GetIssuesModel
            {
                Issues = IssuesbySeverity,
                IssueCount = IssuesbySeverity.Count,
                ProjectKey = JiraRequestManager.ProjectKey,
                TotalRebound = IssuesbySeverity.Sum(x => x.Rebound)
            };

            return Ok(getBugsModel);
        }



        [HttpGet("GetSearchedIssues")]
        public IActionResult GetSearchedIssues(string text)
        {

            //BUSINESSA ERİŞİP DÖNEN VERİYİ DİREK MODELE SETLEYİP DÖNDER. GELEN VERİNİN KONTROLÜ BUSINESSDA
            var SearchedIssues = _issueService.ListSearchedIssues(text);

            GetIssuesModel getBugsModel = new GetIssuesModel
            {
                Issues = SearchedIssues,
                IssueCount = SearchedIssues.Count,
                ProjectKey = JiraRequestManager.ProjectKey,
                TotalRebound = SearchedIssues.Sum(x => x.Rebound)
            };

            return Ok(getBugsModel);




        }
    }
}

