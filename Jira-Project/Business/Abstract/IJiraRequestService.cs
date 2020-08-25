using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IJiraRequestService
    {
        string GetBugs(int startAt);
        string GetTotal();
    }
}
