using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace ConsoleApp
{
    public static class JiraRequestHelper
    {
        public static string GetIssues()
        {
            string url = "https://temmuzhvlstaj.atlassian.net//rest/api/3/search?jql=project='TSE1'+and+issuetype='Bug'&maxResults=100&fields=summary,updated,created,status,creator,customfield_10029&expand=changelog";
            var client = new RestClient(url);
            client.Authenticator = new HttpBasicAuthenticator("erenyilmazgazi@gmail.com", "hRoockHDH3qHggg1mIxg886D"); //BASIC AUTH

            var request = new RestRequest(Method.GET) { RequestFormat = DataFormat.Json };
            var response = client.Execute(request);
            return response.Content;
        }
    }

   
}
