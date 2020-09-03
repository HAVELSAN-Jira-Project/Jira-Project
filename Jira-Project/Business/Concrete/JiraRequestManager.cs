using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;

namespace Business.Concrete
{
    public class JiraRequestManager : IJiraRequestService
    {
        public static string ProjectKey = "TSE1";
        public static int IssueTypeID = 0;

        public string GetBugs(int startAt)
        {
            

            string url = "https://temmuzhvlstaj.atlassian.net//rest/api/3/search?jql=project="+ProjectKey+
                         "&maxResults=25&fields=issuetype,summary,updated,created,status,creator,customfield_10029&expand=changelog&startAt=" + startAt;
            var client = new RestClient(url);
            client.Authenticator = new HttpBasicAuthenticator("erenyilmazgazi@gmail.com", "hRoockHDH3qHggg1mIxg886D"); //BASIC AUTH

            var request = new RestRequest(Method.GET) { RequestFormat = DataFormat.Json };
            var response = client.Execute(request);
            return response.Content;
        }


        public string GetTotal()
        {
            string url = "https://temmuzhvlstaj.atlassian.net//rest/api/3/search?jql=project="+ProjectKey+"&maxResults=100&fields=&expand=changelog";
            var client = new RestClient(url);
            client.Authenticator = new HttpBasicAuthenticator("erenyilmazgazi@gmail.com", "hRoockHDH3qHggg1mIxg886D"); //BASIC AUTH

            var request = new RestRequest(Method.GET) { RequestFormat = DataFormat.Json };
            var response = client.Execute(request);
            return response.Content;
        }
    }
}
