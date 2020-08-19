
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

            List<EntityBug> bugs = DeserializeHelper.DeserializeBugs();        //PROJENİN TÜM BUGLARI
            List<EntityChangeLog> logs = DeserializeHelper.DeserializeLogs();  //PROJEDEKİ BUGLARIN TÜM LOGLARI

            Console.ReadLine();








        }
    }
}
