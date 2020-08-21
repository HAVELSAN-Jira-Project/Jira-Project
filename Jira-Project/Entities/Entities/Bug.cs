using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Entities
{
    public class Bug
    {
        public Bug()
        {
            Logs = new List<Log>();
        }

        [Key]
        public string BugID { get; set; }
        public string Summary { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Status { get; set; }
        public decimal? Severity { get; set; } 

        public List<Log> Logs { get; set; }   //BİR BUGIN BİRDEN ÇOK LOGU 
    }
}
