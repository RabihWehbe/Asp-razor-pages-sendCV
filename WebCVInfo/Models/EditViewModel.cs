using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace WebCVInfo.Models
{
    public class EditViewModel
    {
        public string Name { get; set; } = string.Empty;

        

        public string DoB { get; set; } = string.Empty;

        public string gender { get; set; } = string.Empty;//radio buttons

        public List<string> skills { get; set; } = null;

        public string image_path { get; set; } = string.Empty;
    }
}
