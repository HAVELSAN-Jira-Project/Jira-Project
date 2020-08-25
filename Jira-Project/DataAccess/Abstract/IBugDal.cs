using System;
using System.Collections.Generic;
using System.Text;
using Entities.Entities;

namespace DataAccess.Abstract
{
    public interface IBugDal
    {
        List<Bug> ListBugs();
        Bug ListBug(int id);
        bool Add(List<Bug> Bugs);
        void ClearBugs();
    }
}
