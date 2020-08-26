using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Entities;

namespace AspCoreWebAPI.Models
{
    public class GetBugsModel
    {
        public List<Bug> Bugs { get; set; }
        public int BugCount { get; set; }
        public string ProjectKey { get; set; }
    }
}
