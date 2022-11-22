using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebCVInfo.Models
{
    public class InfoBindingModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayName("date of birth")]
        public string DoB { get; set; }
        [Required]
        public string Nationality { get; set; }//dropdown list
        [Required]
        public string gender { get; set; }//radio buttons
        [Required]
        public IFormFile formFile { get; set; }
    }
}
