using ConsoleApp.Models.ChangeLogs;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string bugResponse = JiraRequestHelper.GetIssues();
            Bugs bugs = JsonConvert.DeserializeObject<Bugs>(bugResponse);
            Console.WriteLine("Issues");
            Console.WriteLine("-----------------------------------------------------------------------");


            List<EntityBug> BugList = new List<EntityBug>();

            foreach (Issue issue in bugs.Issues)
            {
                BugList.Add(new EntityBug
                {
                    BugID = issue.Key,
                    Summary = issue.Fields.Summary,
                    CreateDate = issue.Fields.Created,
                    UpdateDate = issue.Fields.Updated,
                    Creator = issue.Fields.Creator.DisplayName,
                    Status = issue.Fields.Status.Name

                });
                
            }

            foreach (EntityBug entityBugs in BugList)
            {
                Console.WriteLine("Key : {0}", entityBugs.BugID);
                Console.WriteLine("Summary : {0}", entityBugs.Summary);
                Console.WriteLine("Creator : {0}", entityBugs.Creator);
                Console.WriteLine("Create Date : {0}", entityBugs.CreateDate);
                Console.WriteLine("Last Update : {0}", entityBugs.UpdateDate);
                Console.WriteLine("Status : {0}", entityBugs.Status);
                Console.WriteLine("-------------------------------------------------------");
            }

            //--------------------------------------------------------------------------------------------------------------------

            //string changeLogResponse = JiraRequestHelper.GetChangeLogs();
            //BugChangeLogs changeLogs = JsonConvert.DeserializeObject<BugChangeLogs>(changeLogResponse);

            //List<EntityChangeLog> Logs = new List<EntityChangeLog>();



            //foreach (ChangeLogIssue issue in changeLogs.Issues)
            //{

            //    foreach (History history in issue.Changelog.Histories)
            //    {
            //        foreach (Item item in history.Items)
            //        {
            //            EntityChangeLog entityChangeLog = new EntityChangeLog
            //            {
            //                Key = issue.Key,
            //                Author = history.Author.DisplayName,
            //                CreatedDate = history.created,

            //                //FIELDS
            //                Field = item.field,
            //                FieldType = item.fieldtype,
            //                From = item.from,
            //                FromString = item.fromString,
            //                To = item.to,
            //                toString = item.toString

            //            };

            //            
            //            Logs.Add(entityChangeLog);
            //        }
            //    }
            //}



            //foreach (EntityChangeLog log in Logs)
            //{
            //    Console.WriteLine("Key : {0} Author : {1} Created : {2}", log.Key, log.Author, log.CreatedDate);
            //    Console.WriteLine();
            //    Console.WriteLine("Fields");
            //    Console.WriteLine();
            //    Console.WriteLine("Field : {0}", log.Field);
            //    Console.WriteLine("FieldType : {0}", log.FieldType);
            //    Console.WriteLine("From : {0}", log.From);
            //    Console.WriteLine("FromString : {0}", log.FromString);
            //    Console.WriteLine("To : {0}", log.To);
            //    Console.WriteLine("ToString : {0}", log.toString);
            //    Console.WriteLine();
            //    Console.WriteLine();
            //}
            //Console.ReadLine();
        }
    }
}
