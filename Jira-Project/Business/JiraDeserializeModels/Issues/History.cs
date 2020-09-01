using System;
using System.Collections.Generic;
using System.Text;

namespace Business.JiraDeserializeModels.Bugs
{
    public class History
    {
        public DateTime Created { get; set; }
        public Author Author { get; set; }
        public List<Item> Items { get; set; }
    }
}
