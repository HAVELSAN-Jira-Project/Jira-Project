using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.JiraDeserializeModels;
using Business.JiraDeserializeModels.Bugs;
using DataAccess.Abstract;
using DataAccess.ViewModels;
using Newtonsoft.Json;
using Entities.Entities;

namespace Business.Concrete
{
    public class IssueManager : IIssueService
    {
        private readonly IIssueDal _issueDal;
        private readonly IJiraRequestService _jiraRequestService;

        //DEPENDENCY INJECTION
        public IssueManager(IIssueDal issuedal, IJiraRequestService jiraRequestService )
        {
            _issueDal = issuedal;
            _jiraRequestService = jiraRequestService;
        }



        //LİST ALL ISSUES
        public List<ListIssuesViewModel> ListIssues()
        {
            int IssueID = JiraRequestManager.IssueTypeID;
            var ListIssues = new List<ListIssuesViewModel>();

            if (IssueID == 0)  //TÜM ISSUELAR
            {
                ListIssues = _issueDal.ListIssuesWithRebound();
            }
            else  //ISSUE TİPİ UYANLARI GETİR
            {
                ListIssues = _issueDal.ListIssuesWithRebound(IssueID);
            }

            return ListIssues;
        } 





        //TARİH FİLTRESİ
        public List<ListIssuesViewModel> ListIssuesFilterbyDate(int targetDate)
        {
            try
            {
                int IssueID = JiraRequestManager.IssueTypeID;
                var IssuesbyDate = new List<ListIssuesViewModel>();

                if (IssueID == 0) //TUM ISSUELAR 
                {
                    if (targetDate == 1000) //TÜM TARİHLER
                    {
                        IssuesbyDate = _issueDal.ListIssuesWithRebound();
                    }
                    else  //TARİHE UYAN TUM ISSUELAR
                    {
                        DateTime limitDate = DateTime.Now.AddDays(-targetDate);
                        IssuesbyDate = _issueDal.ListIssuesFilterbyDate(limitDate);
                    }
                }
                else //ISSUE TİPİ UYANLAR
                {
                    if (targetDate == 1000) //TÜM TARİHLER
                    {
                        IssuesbyDate = _issueDal.ListIssuesWithRebound(IssueID);
                    }
                    else //ISSUE TİPİ VE TARİHİ UYANLAR
                    {
                        DateTime limitDate = DateTime.Now.AddDays(-targetDate);
                        IssuesbyDate = _issueDal.ListIssuesFilterbyDate(limitDate, IssueID);
                    }
                }
                
                return IssuesbyDate;
            }
            catch
            {
                throw new ApplicationException("Issue'lar Tarihe Göre Filtrelenemedi");
            }
        } 





        //SEVERİTY FİLTRESİ
        public List<ListIssuesViewModel> ListIssuesFilterbySeverity(int severity)
        {
            try
            {
                int IssueID = JiraRequestManager.IssueTypeID;
                var IssuesbySeverity = new List<ListIssuesViewModel>();

                if (IssueID == 0) //TÜM ISSUELAR
                {
                    if (severity == 1000) //TÜM SEVERİTY DEĞERLERİ
                    {
                        IssuesbySeverity = _issueDal.ListIssuesWithRebound();
                    }
                    else //GELEN SEVERİTY DEĞERİNE GÖRE TÜM ISSUELAR
                    {
                        IssuesbySeverity = _issueDal.ListIssuesFilterbySeverity(severity);
                    }
                }

                else
                {
                    if (severity == 1000) //TÜM SEVERİTY DEĞERLERİ
                    {
                        IssuesbySeverity = _issueDal.ListIssuesWithRebound(IssueID);
                    }
                    else  //GELEN SEVERİTY DEĞERİ VE ISSUE TİPİNE GÖRE FİLTRELE
                    {
                        IssuesbySeverity = _issueDal.ListIssuesFilterbySeverity(severity, IssueID);
                    }
                }
                
                return IssuesbySeverity;
            }
            catch
            {
                throw new ApplicationException("Issue'lar Severity Değerine Göre Filtrelenemedi.");
            }
        }





        //ARAMA 
        public List<ListIssuesViewModel> ListSearchedIssues(string text)
        {
            try
            {
                int IssueID = JiraRequestManager.IssueTypeID;
                var SearchedIssues = new List<ListIssuesViewModel>();

                if (IssueID == 0) //TÜM ISSUELAR
                {
                    if (text == null || text == "") //FİLTRE YOK
                    {
                        SearchedIssues = _issueDal.ListIssuesWithRebound();
                    }
                    else  //GELEN TEXTE GÖRE TÜM ISSUELARI DÖNDER
                    {
                        SearchedIssues = _issueDal.ListSearchedIssues(text);
                    }
                }

                else  //ISSUE TİPİNE GÖRE FİLTRELE
                {
                    if (text == null || text == "") //TEXT FİLTRESİ YOK
                    {
                        SearchedIssues = _issueDal.ListIssuesWithRebound(IssueID);
                    }
                    else
                    {
                        SearchedIssues = _issueDal.ListSearchedIssues(text, IssueID);
                    }
                }
               

                return SearchedIssues;
            }
            catch
            {
                throw new ApplicationException("Issue'lar Aramaya Göre Filtrelenemedi.");
            }
        }





        //ISSUE'LARI VERİTABANINA EKLE
        public bool AddIssues() 
        {
            try
            {
                List<JiraIssue> IssueList = GetIssues();

                if (!IssueList.Any())
                    return false;  //LİSTE BOŞ İSE FALSE DÖN


                bool result = _issueDal.Add(IssueList);  //DEĞİLSE DATAACCESSDEN DÖNEN SONUCU DÖN
                return result;
            }
            catch
            {
                return false;
            }
        }


        //JİRADAN ISSUE'LARI ÇEK
        private List<JiraIssue> GetIssues() 
        {
            int startAt = 0;
            int totalValue = GetTotalValue();
            List<JiraIssue> issueList = new List<JiraIssue>();


            for (int i = totalValue; i > 0; i = i - 25)  //TOTAL = TOTAL-MAXRESULT
            {
                string response = _jiraRequestService.GetBugs(startAt);
                Bugs bugs = JsonConvert.DeserializeObject<Bugs>(response);


                foreach (var issue in bugs.Issues)  //REQUESTTE DÖNEN TÜM BUGLARI EKLE
                {
                    issueList.Add(new JiraIssue
                    {
                        IssueID = issue.Key,
                        Summary = issue.Fields.Summary,
                        Type = issue.Fields.issuetype.name,
                        Creator = issue.Fields.Creator.DisplayName,
                        Created = issue.Fields.Created,
                        LastUpdated = issue.Fields.Updated,
                        Status = issue.Fields.Status.Name,
                        Severity = (decimal?)issue.Fields.customfield_10029
                    });

                }     //TOTALVALUE-25 >0 İSE HALA BUG VAR DEMEK. DÖNGÜ BAŞA DÖNSÜN

                startAt += 25;
            }

            return issueList;
        }



        //JİRADAN TOTALVALUE DEĞERİNİ ÇEK
        private int GetTotalValue()  
        {
            string response = _jiraRequestService.GetTotal();
            Total total = JsonConvert.DeserializeObject<Total>(response);

            int totalValue = total.total;
            return totalValue;
        }



        //ISSUES TABLOSUNU TEMİZLE
        public bool ClearIssues()
        {
            try
            {
                _issueDal.ClearIssues();
                return true;
            }
            catch
            {
                return false;
            }
        }   

    }
}
