using System;
using System.Collections.Generic;
using System.Text;
using Entities.Entities;

namespace Business.Abstract
{
    public interface ILogService
    {
        List<Log> ListLogs();
        bool AddLogs();
        bool ClearLogs();

    }
}
