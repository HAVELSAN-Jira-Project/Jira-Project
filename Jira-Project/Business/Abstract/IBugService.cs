using System;
using System.Collections.Generic;
using System.Text;
using Entities.Entities;

namespace Business.Abstract
{
    public interface IBugService
    {
        List<Bug> ListBugs();
        bool AddBugs();
        
    }
}
