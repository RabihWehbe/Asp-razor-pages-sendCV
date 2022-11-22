using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebCVInfo.Data;
using WebCVInfo.Models;

namespace WebCVInfo.Pages
{
    public class detailsModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public string name { get; set; }

        public InternView iv { get; set; } = new InternView();
        public GetInternService _getInternService { get; set; }

        public AppDBContext _context { get; set; }

        public detailsModel(AppDBContext context,GetInternService getInternService)
        {
            _context = context;
            _getInternService = getInternService;
        }
        public async Task OnGet()
        {
            iv = await _getInternService.getIntern(name);
        }
    }
}
