using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Business.JiraDeserializeModels;
using Business.JiraDeserializeModels.Bugs;
using DataAccess.Abstract;
using DataAccess.ViewModels;
using Entities.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;


namespace Business.Concrete
{
    public class BugManager : IBugService
    {
        private readonly IJiraRequestService _jiraRequestService;
        private readonly IBugDal _bugDal;

        //DEPENDENCY INJECTION
        public BugManager(IJiraRequestService jiraRequestService, IBugDal BugDal)
        {
            _jiraRequestService = jiraRequestService;
            _bugDal = BugDal;
        }


        public List<ListIssuesViewModel> ListBugs()  //BUGLARI DBDEN ÇEK
        {
            List<ListIssuesViewModel> ListBugs = _bugDal.ListBugsWithRebound();
            return ListBugs;
        }



        //TARİH FİLTRESİ
        public List<ListIssuesViewModel> ListBugsFilterbyDate(int targetDate)
        {
            try
            {
                var BugsbyDate = new List<ListIssuesViewModel>();

                if (targetDate == 1000) //FİLTRE YOK, TÜMÜNÜ ÇEK
                    BugsbyDate = _bugDal.ListBugsWithRebound();

                else //FİLTRELİ VERİYİ ÇEK
                {
                    DateTime limitDate = DateTime.Now.AddDays(-targetDate);
                    BugsbyDate = _bugDal.ListBugsWithReboundFilterbyDate(limitDate);
                }

                return BugsbyDate;
            }
            catch
            {
                throw new ApplicationException("Buglar Tarihe Göre Filtrelenemedi");
            }
        }


        //SEVERİTY FİLTRESİ
        public List<ListIssuesViewModel> ListBugsFilterbySeverity(int severity)
        {
            try
            {
                var BugsbySeverity = new List<ListIssuesViewModel>();

                if (severity == 1000)
                    BugsbySeverity = _bugDal.ListBugsWithRebound();

                else
                {
                    BugsbySeverity = _bugDal.ListBugsWithReboundFilterbySeverity(severity);
                }

                return BugsbySeverity;
            }
            catch
            {
                throw new ApplicationException("Buglar Severity'e göre filtrelenemedi.");
            }
        }


        //ARAMA 
        public List<ListIssuesViewModel> ListSearchedBugs(string text)
        {
            try
            {
                var SearchedBugs = new List<ListIssuesViewModel>();

                if (text == null || text == "")
                    SearchedBugs = _bugDal.ListBugsWithRebound();    //TÜM BUGLARI GETİR
                else
                {
                    SearchedBugs = _bugDal.ListSearchedBugs(text);   //FİLTRELİ BUGLARI GETİR
                }

                return SearchedBugs;
            }
            catch
            {
                throw new ApplicationException("Bir Hata Oluştu");
            }
        }

    }
}
