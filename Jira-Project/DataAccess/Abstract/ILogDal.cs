using System;
using System.Collections.Generic;
using System.Text;
using Entities.Entities;

namespace DataAccess.Abstract
{
    public interface ILogDal
    {
        List<Log> ListLogs();
        Log ListLog(int id);
        bool Add(List<Log> Logs);
        void ClearLogs();
    }
}
