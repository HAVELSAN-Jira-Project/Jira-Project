using Newtonsoft.Json;
using RestSharp;
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
            Console.WriteLine("Hello");
            Console.WriteLine("-----------------------------------------------");

            var client = new RestClient("http://localhost:61775/api/api");  //LOCALDEKİ REST API
            client.Timeout = -1;
            var request = new RestRequest(Method.GET) { RequestFormat = DataFormat.Json };  //POST REQUEST ATILACAK
            var response = client.Execute(request);  //REQUESTİ EXECUTE ET

             

            List<Product> Products = JsonConvert.DeserializeObject<List<Product>>(response.Content); //NESNEYE ÇEVİR
           



            foreach (Product item in Products)  //ekrana bas
            {
               
                Console.WriteLine("Product ID : {0}", item.productID);
                Console.WriteLine("Product Name : {0}", item.productName);
                Console.WriteLine("Category ID : {0}", item.categoryID);
                Console.WriteLine("Company ID : {0}", item.companyID);
                Console.WriteLine("Price : {0}", item.price);
                Console.WriteLine("Quantity : {0}", item.quantityPerUnit);
                Console.WriteLine("-----------------------------------------------");
            }

            Console.ReadLine();
        }
    }
}
