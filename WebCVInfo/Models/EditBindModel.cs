using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel;

namespace WebCVInfo.Models
{
    public class EditBindModel
    {
        public string Name { get; set; } = null;

        [DisplayName("date of birth")]

        public string DoB { get; set; } = null;

        public string gender { get; set; } = null;//radio buttons

        public List<string> skills { get; set; } = null;

        public IFormFile formFile { get; set; } = null;
    }
}
