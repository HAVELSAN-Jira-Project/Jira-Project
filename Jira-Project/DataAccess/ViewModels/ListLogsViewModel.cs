using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.ViewModels
{
    public class ListLogsViewModel
    {
        public string BugID { get; set; }
        public string Type { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
        public string Field { get; set; }
        public string FromString { get; set; }
        public string toString { get; set; }
    }
}
