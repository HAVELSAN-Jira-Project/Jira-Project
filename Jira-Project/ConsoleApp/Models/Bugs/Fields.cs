using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Fields
    {
        public string Summary { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Creator Creator { get; set; }
        public Status Status { get; set; }
        public double? customfield_10029 { get; set; }
    }
}
