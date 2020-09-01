using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.ViewModels;
using Entities.Entities;

namespace Business.Abstract
{
    public interface IIssueService
    {
        List<ListIssuesViewModel> ListIssues();
        List<ListIssuesViewModel> ListIssuesFilterbyDate(int targetDate);
        List<ListIssuesViewModel> ListIssuesFilterbySeverity(int severity);
        List<ListIssuesViewModel> ListSearchedIssues(string text);
        bool AddIssues();
        bool ClearIssues();


    }
}
