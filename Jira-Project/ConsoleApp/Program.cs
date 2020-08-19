
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Models.Bugs;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string response = JiraRequestHelper.GetIssues();
            Bugs bugs = JsonConvert.DeserializeObject<Bugs>(response);

            List<EntityBug> bugList = new List<EntityBug>();
            List<EntityChangeLog> logList = new List<EntityChangeLog>();



            foreach (Issue issue in bugs.Issues)
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

                foreach (History history in issue.ChangeLog.Histories)
                {
                    foreach (Item item in history.Items)
                    {
                        if (item.Field == "status" || item.Field == "Severity")  //SADECE STATUS VE SEVERİTY LOGLARINI EKLE
                        {
                            logList.Add(new EntityChangeLog{
                                
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

            Console.ReadLine();








        }
    }
}
