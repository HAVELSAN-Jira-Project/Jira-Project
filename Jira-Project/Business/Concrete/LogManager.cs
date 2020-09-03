using Business.Abstract;
using Business.JiraDeserializeModels;
using Business.JiraDeserializeModels.Bugs;
using DataAccess.Abstract;
using Entities.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.ViewModels;
using Microsoft.EntityFrameworkCore.Internal;

namespace Business.Concrete
{
    public class LogManager : ILogService
    {
        private readonly IJiraRequestService _jiraRequestService;
        private readonly ILogDal _logDal;


        //DEPENDENCY INJECTION
        public LogManager(IJiraRequestService jiraRequestService, ILogDal logDal)
        {
            _jiraRequestService = jiraRequestService;
            _logDal = logDal;
        }



        //LOGLARI LİSTELE
        public List<ListLogsViewModel> ListLogs()
        {
            int IssueID = JiraRequestManager.IssueTypeID;

            if (IssueID == 0)  //TÜM ISSUELAR
            {
                List<ListLogsViewModel> Logs = _logDal.ListLogs();
                return Logs;
            }
            else    //GELEN ID'Lİ ISSUELAR
            {
                List<ListLogsViewModel> Logs = _logDal.ListLogs(IssueID);
                return Logs;
            }
            
            
        } //!




        //TARİHE GÖRE FİLTRELE
        public List<ListLogsViewModel> ListLogsFilterbyDate(int day)
        {
           
            try
            {
                int IssueID = JiraRequestManager.IssueTypeID;
                List<ListLogsViewModel> GetLogs = new List<ListLogsViewModel>();


                if (IssueID == 0)
                {
                    if (day == 1000)
                    {
                        GetLogs = _logDal.ListLogs();  //TÜM LOGLARI ÇEK
                    }
                    else
                    {
                        DateTime limitDate = DateTime.Now.AddDays(-day);
                        GetLogs = _logDal.ListLogsFiltebyDate(limitDate);  //TARİHE UYAN TÜM ISSUELARI GETİR
                    }
                   
                }

                else
                {
                    if (day == 1000)
                        GetLogs = _logDal.ListLogs(IssueID);  //ISSUE TİPİ UYAN TÜM LOGLARI ÇEK

                    else
                    {
                        DateTime limitDate = DateTime.Now.AddDays(-day);  //ISSUE TİPİNE VE TARİHE GÖRE FİLTRELE
                        GetLogs = _logDal.ListLogsFiltebyDate(limitDate, IssueID);
                    }
                }


                return GetLogs;
            }
            catch
            {
                throw new ApplicationException("Loglar Tarihe Göre Filtrelenemedi.");
            }
        }




        //STATÜYE GÖRE FİLTRELE
        public List<ListLogsViewModel> ListLogsFilterbyStatus(int statusID)
        {
            try
            {
                int IssueID = JiraRequestManager.IssueTypeID;
                var getLogs = new List<ListLogsViewModel>();


                if (IssueID == 0)  //TÜM LOGLARI GETİR 
                {
                    if (statusID == 1000) //TARİH FİLTRESİ YOK
                    {
                        getLogs = _logDal.ListLogs();
                    }
                    else  //TARİH FİLTRESİ VAR 
                    {
                        getLogs = _logDal.ListLogsFilterbyStatus(statusID);
                    }
                }
                else  //ISSUE TİPİ UYAN LOGLARI GETİR
                {
                    if (statusID == 1000)
                    {
                        getLogs = _logDal.ListLogs(IssueID);
                    }
                    else
                    {
                        getLogs = _logDal.ListLogsFilterbyStatus(statusID, IssueID);
                    }
                }

                return getLogs;
            }
            catch
            {
                throw new ApplicationException("Loglar Statüye Göre Filtrelenemedi");
            }
        }  






        //ISSUE IDYE GÖRE LOGLARI LİSTELE
        public List<ListLogsViewModel> ListLogsbyID(string id)
        {
            if (id == null)
            {
                throw new  ApplicationException("BugID Hatalı.");
            }

            var result = _logDal.ListLogsbyID(id);
            return result;
        }  //!




        //LOGLARI DBYE EKLE
        public bool AddLogs()   
        {
            try
            {
                List<Log> LogList = GetLogs();

                if (!LogList.Any())
                    return false;   //LİSTE BOŞ İSE FALSE DÖN


                bool result = _logDal.Add(LogList);
                return result;
            }
            catch 
            {
                throw new ApplicationException("Loglar Veritabanına Eklenemedi");
            }
            
           
        }  //!




        //JİRADAN LOGLARI ÇEK, AYIKLA
        private List<Log> GetLogs()  
        {
            int startAt = 0;
            int totalValue = GetTotalValue();
            List<Log> logList = new List<Log>();

            for (int i = totalValue; i > 0; i = i - 25)
            {
                string response = _jiraRequestService.GetBugs(startAt);
                Bugs bugs = JsonConvert.DeserializeObject<Bugs>(response);

                foreach (var issue in bugs.Issues)
                {
                    foreach (History history in issue.ChangeLog.Histories)
                    {
                        foreach (Item item in history.Items)
                        {
                            if (item.Field == "status" || item.Field == "Severity")  //SADECE STATUS VE SEVERİTY LOGLARINI EKLE
                            {
                                logList.Add(new Log()
                                {

                                    IssueID = issue.Key,
                                    Author = history.Author.DisplayName,     //KİM DEĞİŞMİŞ
                                    LogType = issue.Fields.issuetype.name,   //ISSUE TİPİ
                                    Created = history.Created,               //NE ZAMAN DEĞİŞMİŞ
                                    Field = item.Field,                      //NEREYİ DEĞİŞMİŞ
                                    FromString = item.FromString,            //ÖNCEKİ DURUMU
                                    toString = item.toString                 //SONRAKİ DURUMU

                                });
                            }
                        }
                    }
                }

                startAt += 25;
            }

            return logList;
        } //!




        //JİRADAN TOTALVALUE DEĞERİNİ DÖNDÜR
        private int GetTotalValue()  
        {
            string response = _jiraRequestService.GetTotal();
            Total total = JsonConvert.DeserializeObject<Total>(response);

            int totalValue = total.total;
            return totalValue;
        } //!




        //LOGS TABLOSUNUZ TEMİZLE
        public bool ClearLogs()
        {
            try
            {
                _logDal.ClearLogs();
                return true;
            }
            catch
            {
                return false;
            }
        }  //!


       


       
    }
}
