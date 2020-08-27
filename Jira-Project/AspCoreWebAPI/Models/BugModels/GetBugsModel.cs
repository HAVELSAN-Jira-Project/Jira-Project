using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.ViewModels;
using Entities.Entities;

namespace AspCoreWebAPI.Models
{
    public class GetBugsModel
    {
        public List<ListBugsViewModel> Bugs { get; set; }
        public int BugCount { get; set; }
        public string ProjectKey { get; set; }
        public int TotalRebound { get; set; }
    }
}
