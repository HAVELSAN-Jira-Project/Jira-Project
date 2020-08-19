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
    public static class JiraRequestHelper  //REQUEST BUSINESS METHOTLARI
    {
        public static string GetIssues(int startAt)
        {
            string url = "https://temmuzhvlstaj.atlassian.net//rest/api/3/search?jql=project='TSE1'+and+issuetype='Bug'" +
                         "&maxResults=2&fields=summary,updated,created,status,creator,customfield_10029&expand=changelog&startAt="+startAt;
            var client = new RestClient(url);
            client.Authenticator = new HttpBasicAuthenticator("erenyilmazgazi@gmail.com", "hRoockHDH3qHggg1mIxg886D"); //BASIC AUTH

            var request = new RestRequest(Method.GET) { RequestFormat = DataFormat.Json };
            var response = client.Execute(request);
            return response.Content;
        }

        public static string GetTotal()
        {
            string url = "https://temmuzhvlstaj.atlassian.net//rest/api/3/search?jql=project='TSE1'" +
                         "+and+issuetype='Bug'&maxResults=100&fields=&expand=changelog";
            var client = new RestClient(url);
            client.Authenticator = new HttpBasicAuthenticator("erenyilmazgazi@gmail.com", "hRoockHDH3qHggg1mIxg886D"); //BASIC AUTH

            var request = new RestRequest(Method.GET) { RequestFormat = DataFormat.Json };
            var response = client.Execute(request);
            return response.Content;
        }
    }

   
}
