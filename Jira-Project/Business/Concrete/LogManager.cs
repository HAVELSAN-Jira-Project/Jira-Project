using Business.Abstract;
using Business.JiraDeserializeModels;
using Business.JiraDeserializeModels.Bugs;
using DataAccess.Abstract;
using Entities.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class LogManager : ILogService
    {
        private readonly IJiraRequestService _jiraRequestService;
        private readonly ILogDal _logDal;

        public LogManager(IJiraRequestService jiraRequestService, ILogDal logDal)
        {
            _jiraRequestService = jiraRequestService;
            _logDal = logDal;
        }

        public List<Log> ListLogs()  //LOGLARI DBDEN ÇEK
        {
            List<Log> Logs = _logDal.ListLogs();
            return Logs;
        }

        public bool AddLogs()     //LOGLARI DBYE EKLE
        {
            try
            {
                List<Log> LogList = GetLogs();
                bool result = _logDal.Add(LogList);

                return result;
            }
            catch
            {
                throw new ApplicationException("Bir Hata Oluştu");
            }
        }

        private List<Log> GetLogs()  //LOGLARI DÖNDÜR
        {
            int startAt = 0;
            int totalValue = GetTotalValue();
            List<Log> logList = new List<Log>();

            for (int i = totalValue; i > 0; i = i - 25)
            {
                string response = _jiraRequestService.GetBugs(startAt);
                Bugs bugs = JsonConvert.DeserializeObject<Bugs>(response);

                foreach (Issue issue in bugs.Issues)
                {
                    foreach (History history in issue.ChangeLog.Histories)
                    {
                        foreach (Item item in history.Items)
                        {
                            if (item.Field == "status" || item.Field == "Severity")  //SADECE STATUS VE SEVERİTY LOGLARINI EKLE
                            {
                                logList.Add(new Log()
                                {

                                    BugID = issue.Key,
                                    Author = history.Author.DisplayName,  //KİM DEĞİŞMİŞ
                                    Created = history.Created,        //NE ZAMAN DEĞİŞMİŞ
                                    Field = item.Field,                   //NEREYİ DEĞİŞMİŞ
                                    FromString = item.FromString,         //ÖNCEKİ DURUMU
                                    toString = item.toString              //SONRAKİ DURUMU

                                });
                            }
                        }
                    }
                }

                startAt += 25;
            }

            return logList;
        }

        private int GetTotalValue()  //TOTALVALUE DÖNDÜR
        {
            string response = _jiraRequestService.GetTotal();
            Total total = JsonConvert.DeserializeObject<Total>(response);

            int totalValue = total.total;
            return totalValue;
        }
    }
}
