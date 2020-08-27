using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.ViewModels;
using Entities.Entities;

namespace DataAccess.Abstract
{
    public interface IBugDal
    {
        Bug ListBug(int id);
        bool Add(List<Bug> Bugs);
        void ClearBugs();
        List<ListBugsViewModel> ListBugsWithRebound();
        List<ListBugsViewModel> ListBugsWithReboundFilterbyDate(DateTime targetTime);
        List<ListBugsViewModel> ListBugsWithReboundFilterbySeverity(int severity);
        List<ListBugsViewModel> ListSearchedBugs(string text);


    }
}
