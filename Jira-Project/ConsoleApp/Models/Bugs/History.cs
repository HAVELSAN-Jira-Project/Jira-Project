using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models.Bugs
{
    public class History
    {
        public DateTime Created { get; set; }
        public Author Author { get; set; }
        public List<Item> Items { get; set; }
    }
}
