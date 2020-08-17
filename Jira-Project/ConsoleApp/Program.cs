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
            Example example = JsonConvert.DeserializeObject<Example>(response);
            Console.WriteLine("{0} {1} {2} {3}", example.Expand, example.StartAt, example.MaxResults, example.Total);
            Console.WriteLine("Issue Fields");
            Console.WriteLine("-----------------------------------------------------------------------");

            foreach (Issue item in example.Issues)  //EXAMPLEDAKİ HER BİR ISSUE'YU DÖN
            {
                Console.WriteLine("Key : {0}", item.Key);
                Console.WriteLine("Summary : {0}",item.Fields.Summary);
                Console.WriteLine("Created : {0}",item.Fields.Created);
                Console.WriteLine("Updated : {0}", item.Fields.Updated);
                Console.WriteLine("-----------------------------------------------------------------------");

            }
            Console.ReadLine();
        }
    }
}
