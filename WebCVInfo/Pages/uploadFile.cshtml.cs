using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Threading.Tasks;

namespace WebCVInfo.Pages
{
    public class uploadFileModel : PageModel
    {
        [System.Obsolete]
        private IHostingEnvironment _environment;
        public void OnGet()
        {
        }

        [System.Obsolete]
        public uploadFileModel(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        [BindProperty]
        public IFormFile Upload { get; set; }

        [System.Obsolete]
        public async Task OnPostAsync()
        {
            var file = Path.Combine(_environment.ContentRootPath, "wwwroot/uploads", Upload.FileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await Upload.CopyToAsync(fileStream);
            }
        }
    }
}
