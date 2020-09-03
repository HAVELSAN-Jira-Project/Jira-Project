using System;
using System.Collections.Generic;
using System.Text;

namespace Business.JiraDeserializeModels.Bugs
{
    public class Fields
    {
        public string Summary { get; set; }
        public Issuetype issuetype { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Creator Creator { get; set; }
        public Status Status { get; set; }
        public double? customfield_10029 { get; set; }
    }
}
