using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace ConsoleApp
{
    public static class Request
    {
        public static string GetIssue(int id)
        {
            string url = "https://temmuzhvlstaj.atlassian.net/rest/api/3/issue/TSE1-" + id;
            var client = new RestClient(url);
            client.Authenticator = new HttpBasicAuthenticator("erenyilmazgazi@gmail.com", "hRoockHDH3qHggg1mIxg886D"); //BASIC AUTH

            var request = new RestRequest(Method.GET) { RequestFormat = DataFormat.Json };  //POST REQUEST ATILACAK
            var response = client.Execute(request);  //REQUESTİ EXECUTE ET
            return response.Content;
        } 
    }
}
