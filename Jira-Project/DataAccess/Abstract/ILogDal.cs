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
        List<ListLogsViewModel> ListLogs(int id);
        List<ListLogsViewModel> ListLogsFiltebyDate(DateTime limitDate);
        List<ListLogsViewModel> ListLogsFiltebyDate(DateTime limitDate, int id);
        List<ListLogsViewModel> ListLogsFilterbyStatus(int statusID);
        List<ListLogsViewModel> ListLogsFilterbyStatus(int statusID, int id);
        List<ListLogsViewModel> ListLogsbyID(string id);
        bool Add(List<Log> Logs);
        public void ClearLogs();


    }
}
