using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using WebCVInfo.Models;

namespace WebCVInfo.Pages
{
    public class EditModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public BindEdit BE { get; set; } = new BindEdit();

        [BindProperty]
        public EditBindModel EBM { get; set; } = new EditBindModel();
        public EditInternService _editInternService { get; set; } 

        public EditModel(EditInternService editInternService)
        {
            _editInternService = editInternService;
        }
        public void OnGet()
        {
        }

        [System.Obsolete]
        public async Task<IActionResult> OnPostAsync()
        {
            await _editInternService.EditInfos(EBM,BE.id);
            return Page();
        }

        public class BindEdit
        {
            public int id { get; set; }
            public string name { get; set; }
        }


        public IEnumerable<string> Askills = new List<string>
        {
            "java",
            "C language",
            "C#",
            "DataBase",
        };
    }
}
