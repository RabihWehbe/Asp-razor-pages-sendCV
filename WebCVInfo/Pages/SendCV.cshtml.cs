using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using WebCVInfo.Models;

namespace WebCVInfo.Pages
{
    public class SendCVModel : PageModel
    {

        [System.Obsolete]
        private IHostingEnvironment _environment;

        public SendCVService _sendCVService { get; set; }


        [BindProperty]
        public InfoBindingModel ibm { get; set; } = new InfoBindingModel();

        [BindProperty]
        public List<string> skills { get; set; } = new List<string>
            {
                "default"
            };//checkboxes

        [System.Obsolete]
        public SendCVModel(IHostingEnvironment environment,SendCVService sendCVService)
        {
            _environment = environment;
            _sendCVService = sendCVService;
        }

        public void OnGet()
        {
        }

        [System.Obsolete]
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _sendCVService.UploadImageAsync(ibm.formFile, (Microsoft.Extensions.Hosting.IHostEnvironment)_environment);
            await _sendCVService.AddRecord(ibm, skills);
            return RedirectToPage("index");
        }

        public IEnumerable<SelectListItem> nations = new List<SelectListItem>
        {
            new SelectListItem{Value = "Lebanon",Text="Lebanon"},
            new SelectListItem{Value = "France",Text="France"},
            new SelectListItem{Value = "Russia",Text="Russia"},
            new SelectListItem{Value = "Ukraine",Text="Ukraine"}
        };

        public IEnumerable<string> Askills = new List<string>
        {
            "java",
            "C language",
            "C#",
            "DataBase",
        };

    }
}
