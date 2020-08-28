using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.ViewModels;
using Entities.Entities;

namespace Business.Abstract
{
    public interface IBugService
    {
        List<ListBugsViewModel> ListBugs();
        bool AddBugs();
        bool ClearBugs();
        List<ListBugsViewModel> ListBugsFilterbyDate(int targetDate);
        List<ListBugsViewModel> ListBugsFilterbySeverity(int severity);
        List<ListBugsViewModel> ListSearchedBugs(string text);




    }
}
