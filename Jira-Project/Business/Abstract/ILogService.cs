using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.ViewModels;
using Entities.Entities;

namespace Business.Abstract
{
    public interface ILogService
    {
        List<ListLogsViewModel> ListLogs();
        List<ListLogsViewModel> ListLogsFilterbyDate(int day);
        List<ListLogsViewModel> ListLogsFilterbyStatus(int statusID);
        List<ListLogsViewModel> ListLogsbyID(string id);
        bool AddLogs();
        bool ClearLogs();


    }
}
