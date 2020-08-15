using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Product
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public int categoryID { get; set; }
        public int companyID { get; set; }
        public decimal price { get; set; }
        public string quantityPerUnit { get; set; }
    }
}
