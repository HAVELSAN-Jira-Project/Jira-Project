﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.ViewModels
{
    public class ListBugsViewModel
    {
        public string BugID { get; set; }
        public string Summary { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Status { get; set; }
        public decimal? Severity { get; set; }
        public int Rebound { get; set; }
    }
}
