using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models.ChangeLogs
{
    public class ChangeLogIssue
    {
        public string Key { get; set; }
        public ChangeLog Changelog { get; set; }
    }
}
