using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebCVInfo.Pages
{
    public class CheckSomeModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public string name { get; set; }
        public void OnGet()
        {
        }
    }
}
