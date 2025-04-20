using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YummyProject.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        [Required(ErrorMessage = "Başlık Boş bırakılamaz")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Açıklama Boş bırakılamaz")]
        public string Description { get; set; }
        [Required(ErrorMessage = "İkon Boş bırakılamaz")]
        public string Icon { get; set; }
    }
}