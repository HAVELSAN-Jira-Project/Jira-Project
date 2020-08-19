using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Models;
using ConsoleApp.Models.Bugs;
using Newtonsoft.Json;

namespace ConsoleApp
{
    public static class DeserializeHelper  //SERVICE BUSINESS METHOTLARI
    {
        public static List<EntityBug> DeserializeBugs()  //BUG BUSINESS
        {
            int startAt = 0;
            int totalValue = GetTotalValue();
            List<EntityBug> bugList = new List<EntityBug>();


            for (int i=totalValue; i>0; i=i-2)  //TOTAL = TOTAL-MAXRESULT
            {
                string response = JiraRequestHelper.GetIssues(startAt);
                Bugs bugs = JsonConvert.DeserializeObject<Bugs>(response);


                foreach (Issue issue in bugs.Issues)  //REQUESTTE DÖNEN TÜM BUGLARI EKLE
                {
                    bugList.Add(new EntityBug
                    {
                        BugID = issue.Key,
                        Summary = issue.Fields.Summary,
                        Creator = issue.Fields.Creator.DisplayName,
                        CreateDate = issue.Fields.Created,
                        UpdateDate = issue.Fields.Updated,
                        Status = issue.Fields.Status.Name,
                        Severity = issue.Fields.customfield_10029
                    });
                    
                }     //TOTALVALUE-25 >0 İSE HALA BUG VAR DEMEK. DÖNGÜ BAŞA DÖNSÜN

                startAt += 2;
            }

            return bugList;
        }

        
            public static List<EntityChangeLog> DeserializeLogs()  //LOG BUSINESS
            {
                int startAt = 0;
                int totalValue = GetTotalValue();
                List<EntityChangeLog> logList = new List<EntityChangeLog>();

                for (int i = totalValue; i > 0; i = i - 2)
                {
                    string response = JiraRequestHelper.GetIssues(startAt);
                    Bugs bugs = JsonConvert.DeserializeObject<Bugs>(response);

                    foreach (Issue issue in bugs.Issues)
                    {
                        foreach (History history in issue.ChangeLog.Histories)
                        {
                            foreach (Item item in history.Items)
                            {
                                if (item.Field == "status" || item.Field == "Severity")  //SADECE STATUS VE SEVERİTY LOGLARINI EKLE
                                {
                                    logList.Add(new EntityChangeLog
                                    {

                                        Key = issue.Key,
                                        Author = history.Author.DisplayName,  //KİM DEĞİŞMİŞ
                                        CreatedDate = history.Created,        //NE ZAMAN DEĞİŞMİŞ
                                        Field = item.Field,                   //NEREYİ DEĞİŞMİŞ
                                        FromString = item.FromString,         //ÖNCEKİ DURUMU
                                        toString = item.ToString              //SONRAKİ DURUMU

                                    });
                                }
                            }
                        }
                    }

                    startAt += 2;
                }

                return logList;
            }


            public static int GetTotalValue()  //BUGBUSINESS
            {
                string response = JiraRequestHelper.GetTotal();
                Total total = JsonConvert.DeserializeObject<Total>(response);

                int totalValue = total.total;
                 return totalValue;
            }
        }
}
