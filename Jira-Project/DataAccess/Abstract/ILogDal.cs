using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.ViewModels;
using Entities.Entities;

namespace DataAccess.Abstract
{
    public interface ILogDal
    {
        List<ListLogsViewModel> ListLogs();
        List<ListLogsViewModel> ListLogsbyID(string id);
        bool Add(List<Log> Logs);
        void ClearLogs();
        List<ListLogsViewModel> ListLogsFiltebyDate(DateTime targetTime);
        List<ListLogsViewModel> ListLogsFilterbyStatus(int statusID);


    }
}
