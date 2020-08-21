using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Entities
{
    public class Log
    {
        [Key]
        public int LogID { get; set; }
        public string BugID { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
        public string Field { get; set; }
        public string FromString { get; set; }
        public string toString { get; set; }

        public Bug Bug { get; set; }  //BİR LOG BİR BUGA AİT
    }
}
