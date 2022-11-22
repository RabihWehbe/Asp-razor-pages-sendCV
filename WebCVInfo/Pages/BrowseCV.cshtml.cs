using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebCVInfo.Models;

namespace WebCVInfo.Pages
{
    public class BrowseCVModel : PageModel
    {
        public string name { get; set; } = "Guevara";
        public BrowseInternsService _browseInterns { get; set; }

        public List<InternView> interns { get; set; }

        public BrowseCVModel(BrowseInternsService browseInterns)
        {
            _browseInterns = browseInterns;
        }
        public async Task OnGet()
        {
            interns = await _browseInterns.BrowseInterns();
        }
    }
}
