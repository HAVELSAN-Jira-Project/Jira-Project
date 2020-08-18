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
            string response = JiraRequestHelper.GetIssues();
            Bugs bugs = JsonConvert.DeserializeObject<Bugs>(response);
            Console.WriteLine("{0} {1} {2} {3}", bugs.Expand, bugs.StartAt, bugs.MaxResults, bugs.Total);
            Console.WriteLine("Issue Fields");
            Console.WriteLine("-----------------------------------------------------------------------");

            foreach (Issue item in bugs.Issues)  //EXAMPLEDAKİ HER BİR ISSUE'YU DÖN
            {
                Console.WriteLine("Key : {0}", item.Key);
                Console.WriteLine("Summary : {0}",item.Fields.Summary);
                Console.WriteLine("Created : {0}",item.Fields.Created);
                Console.WriteLine("Updated : {0}", item.Fields.Updated);
                Console.WriteLine("Created by : {0}", item.Fields.Creator.DisplayName);
                Console.WriteLine("Status : {0}", item.Fields.Status.Name);

                Console.WriteLine("-----------------------------------------------------------------------");

            }
            Console.ReadLine();
        }
    }
}
