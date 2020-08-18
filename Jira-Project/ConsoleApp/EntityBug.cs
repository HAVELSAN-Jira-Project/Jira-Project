using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class EntityBug
    {
        
        public string BugID { get; set; }
        public string Summary { get; set; }
        public string Creator { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Status { get; set; }   //ENUM DA OLABİLİR
    }
}
