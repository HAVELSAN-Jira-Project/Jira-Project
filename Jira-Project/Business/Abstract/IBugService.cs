using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.ViewModels;
using Entities.Entities;

namespace Business.Abstract
{
    public interface IBugService
    {
        List<ListIssuesViewModel> ListBugs();
        
        List<ListIssuesViewModel> ListBugsFilterbyDate(int targetDate);
        List<ListIssuesViewModel> ListBugsFilterbySeverity(int severity);
        List<ListIssuesViewModel> ListSearchedBugs(string text);




    }
}
