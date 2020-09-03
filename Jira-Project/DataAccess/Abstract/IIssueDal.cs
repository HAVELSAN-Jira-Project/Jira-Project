using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.ViewModels;
using Entities.Entities;

namespace DataAccess.Abstract
{
    public interface IIssueDal
    {
        bool Add(List<JiraIssue> Issues);
        void ClearIssues();
        List<ListIssuesViewModel> ListIssuesWithRebound();
        List<ListIssuesViewModel> ListIssuesWithRebound(int id);
        List<ListIssuesViewModel> ListIssuesFilterbyDate(DateTime targetTime);
        List<ListIssuesViewModel> ListIssuesFilterbyDate(DateTime targetTime,int id);
        List<ListIssuesViewModel> ListIssuesFilterbySeverity(int severity);
        List<ListIssuesViewModel> ListIssuesFilterbySeverity(int severity, int id);
        List<ListIssuesViewModel> ListSearchedIssues(string text);
        List<ListIssuesViewModel> ListSearchedIssues(string text, int id);
    }
}
