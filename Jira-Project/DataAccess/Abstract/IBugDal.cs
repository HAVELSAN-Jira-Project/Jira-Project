using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.ViewModels;
using Entities.Entities;

namespace DataAccess.Abstract
{
    public interface IBugDal
    {
        JiraIssue ListBug(int id);
        List<ListIssuesViewModel> ListBugsWithRebound();
        List<ListIssuesViewModel> ListBugsWithReboundFilterbyDate(DateTime targetTime);
        List<ListIssuesViewModel> ListBugsWithReboundFilterbySeverity(int severity);
        List<ListIssuesViewModel> ListSearchedBugs(string text);


    }
}
