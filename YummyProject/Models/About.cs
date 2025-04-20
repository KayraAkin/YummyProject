using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YummyProject.Models
{
    public class About
    {
        public int AboutId { get; set; }
        [Required(ErrorMessage = "Resim Url Boş bırakılamaz")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Resim Url Boş bırakılamaz")]
        public string ImageUrl2 { get; set; }
        [Required(ErrorMessage = "Madde Boş bırakılamaz")]
        public string Item1 { get; set; }
        [Required(ErrorMessage = "Madde Boş bırakılamaz")]
        public string Item2 { get; set; }
        [Required(ErrorMessage = "Madde Boş bırakılamaz")]
        public string Item3 { get; set; }
        [Required(ErrorMessage = "Açıklama Boş bırakılamaz")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Video Url Boş bırakılamaz")]
        public string VideoUrl { get; set; }
        [Required(ErrorMessage = "Telefon Numarası bırakılamaz")]
        public string PhoneNumber { get; set; }
    }
}