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


        public List<ListBugsViewModel> ListBugs()  //BUGLARI DBDEN ÇEK
        {
            List<ListBugsViewModel> ListBugs = _bugDal.ListBugsWithRebound();
            return ListBugs;
        }


        public bool AddBugs()  //BUGLARI DBYE EKLE
        {
            try
            {
                List<Bug> BugList = GetBugs();

                if (!BugList.Any())
                    return false;  //LİSTE BOŞ İSE FALSE DÖN

                bool result = _bugDal.Add(BugList);  //DEĞİLSE DATAACCESSDEN DÖNEN SONUCU DÖN
                return result;
            }
            catch
            {
                return false;
            }
        }


        private List<Bug> GetBugs()   //BUGLARI DÖNDÜR
        {
            int startAt = 0;
            int totalValue = GetTotalValue();
            List<Bug> bugList = new List<Bug>();


            for (int i = totalValue; i > 0; i = i - 25)  //TOTAL = TOTAL-MAXRESULT
            {
                string response = _jiraRequestService.GetBugs(startAt);
                Bugs bugs = JsonConvert.DeserializeObject<Bugs>(response);


                foreach (Issue issue in bugs.Issues)  //REQUESTTE DÖNEN TÜM BUGLARI EKLE
                {
                    bugList.Add(new Bug
                    {
                        BugID = issue.Key,
                        Summary = issue.Fields.Summary,
                        Creator = issue.Fields.Creator.DisplayName,
                        Created = issue.Fields.Created,
                        LastUpdated = issue.Fields.Updated,
                        Status = issue.Fields.Status.Name,
                        Severity = (decimal?)issue.Fields.customfield_10029
                    });

                }     //TOTALVALUE-25 >0 İSE HALA BUG VAR DEMEK. DÖNGÜ BAŞA DÖNSÜN

                startAt += 25;
            }

            return bugList;
        }


        private int GetTotalValue()  //TOTAL SAYISINI DÖNDÜR
        {
            string response = _jiraRequestService.GetTotal();
            Total total = JsonConvert.DeserializeObject<Total>(response);

            int totalValue = total.total;
            return totalValue;
        }


        public bool ClearBugs()
        {
            try
            {
                _bugDal.ClearBugs();
                return true;
            }
            catch
            {
                return false;
            }
        }   //TRUNCATE TABLE


        //TARİH FİLTRESİ
        public List<ListBugsViewModel> ListBugsFilterbyDate(int targetDate)
        {
            try
            {
                var BugsbyDate = new List<ListBugsViewModel>();

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
        public List<ListBugsViewModel> ListBugsFilterbySeverity(int severity)
        {
            try
            {
                var BugsbySeverity = new List<ListBugsViewModel>();

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
        public List<ListBugsViewModel> ListSearchedBugs(string text)
        {
            try
            {
                var SearchedBugs = new List<ListBugsViewModel>();

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
