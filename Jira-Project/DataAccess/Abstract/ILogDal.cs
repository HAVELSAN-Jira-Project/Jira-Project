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
        Log ListLog(int id);
        bool Add(List<Log> Logs);
        void ClearLogs();
        List<ListLogsViewModel> ListLogsFiltebyDate(DateTime targetTime);


    }
}
