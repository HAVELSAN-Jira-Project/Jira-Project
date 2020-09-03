using System;
using System.Collections.Generic;
using System.Text;

namespace Business.JiraDeserializeModels.Bugs
{
    public class Issue
    {
        public Fields Fields { get; set; }
        public string Key { get; set; }
        public ChangeLog ChangeLog { get; set; }
        public string IssueID { get; set; }
    }
}
