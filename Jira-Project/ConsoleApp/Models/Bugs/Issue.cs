using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Models.Bugs;

namespace ConsoleApp
{
    public class Issue
    {
        public Fields Fields { get; set; }
        public string Key { get; set; }
        public ChangeLog ChangeLog { get; set; }
    }
}
