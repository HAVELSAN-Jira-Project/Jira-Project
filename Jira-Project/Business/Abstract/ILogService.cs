﻿using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.ViewModels;
using Entities.Entities;

namespace Business.Abstract
{
    public interface ILogService
    {
        List<ListLogsViewModel> ListLogs();
        bool AddLogs();
        bool ClearLogs();
        List<ListLogsViewModel> ListLogsFilterbyDate(int day);
        List<ListLogsViewModel> ListLogsFilterbyStatus(int statusID);
        List<ListLogsViewModel> ListLogsbyID(string id);

    }
}
