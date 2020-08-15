using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            var client = new RestClient("http://localhost:61775/api/api");  //LOCALDEKİ REST API
            client.Timeout = -1;
            var request = new RestRequest(Method.GET) { RequestFormat = DataFormat.Json };  //POST REQUEST ATILACAK
            var response = client.Execute(request);  //REQUESTİ EXECUTE ET



            List<Product> Products = JsonConvert.DeserializeObject<List<Product>>(response.Content); //NESNEYE ÇEVİR
            Product product1 = new Product();
            return View();
        }
    }
}
