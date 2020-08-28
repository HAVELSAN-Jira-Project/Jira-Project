using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.ViewModels;
using Entities.Entities;

namespace AspCoreWebAPI.Models.LogsModels
{
    public class GetLogsModel
    {
        public List<ListLogsViewModel> Logs { get; set; }
        public int LogCount { get; set; }
        public string ProjectKey { get; set; }

    }
}
