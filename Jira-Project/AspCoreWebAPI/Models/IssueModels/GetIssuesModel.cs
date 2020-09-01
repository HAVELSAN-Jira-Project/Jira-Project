using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.ViewModels;
using Entities.Entities;

namespace AspCoreWebAPI.Models
{
    public class GetIssuesModel
    {
        public List<ListIssuesViewModel> Issues { get; set; }
        public int IssueCount { get; set; }
        public string ProjectKey { get; set; }
        public int TotalRebound { get; set; }
    }
}
