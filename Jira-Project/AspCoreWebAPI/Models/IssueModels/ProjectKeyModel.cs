using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreWebAPI.Models
{
    public class ProjectKeyModel
    {
        [Required(ErrorMessage = "Lütfen Proje Numarası Girin.")]
        [MaxLength(5,ErrorMessage = "Proje Kodu Uzunluğu 5 Karakteri Geçemez.")]
        public string ProjectKey { get; set; }

    }
}
