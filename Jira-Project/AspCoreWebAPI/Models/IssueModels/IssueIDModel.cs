using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreWebAPI.Models.IssueModels
{
    public class IssueIDModel
    {
        [Required(ErrorMessage = "IssueID null Olamaz.")]
        [Range(0, 4, ErrorMessage = "IssueID 0-4 Aralığında Olmalıdır.")]
        public int? IssueID { get; set; } = null;
    }
}
