using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebCVInfo.Data;

namespace WebCVInfo.Pages
{
    public class DeleteRecordModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int id { get; set; }


        public AppDBContext _context { get; set; }

        public DeleteService _deleteService {get; set;}

        public DeleteRecordModel(DeleteService deleteService,AppDBContext context)
        {
            _deleteService = deleteService;
        }
        public async Task OnGet()
        {
            await _deleteService.DeleteIntern(id);
        }
    }
}
