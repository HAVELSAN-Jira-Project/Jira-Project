using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class EntityChangeLog
    {
        public string Key { get; set; }
        public string Author { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Field { get; set; } 
        public string FieldType { get; set; } 
        public string From { get; set; } 
        public string FromString { get; set; } 
        public string To { get; set; }  
        public string toString { get; set; } 

    }
}
