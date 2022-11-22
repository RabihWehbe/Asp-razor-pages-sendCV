using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using WebCVInfo.Data;
using WebCVInfo.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace WebCVInfo
{
    public class EditInternService
    {
        public AppDBContext _context { get; set; }

        [System.Obsolete]
        private IHostingEnvironment _environment;

        [System.Obsolete]
        public EditInternService(AppDBContext context,IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [System.Obsolete]
        public async Task EditInfos(EditBindModel EBM,int id)
        {
            List<Skill> items = new List<Skill>();

            var intern = await _context.Interns.FindAsync(id);

            //we find the entity of our records to be updated
            //EF core track the entity then and can notice the changes applied to it and then save them by calling saveChanges()

            if (EBM.Name != null) intern.Name = EBM.Name;
            if (EBM.gender != null) intern.gender = EBM.gender;
            if (EBM.DoB != null) intern.DOB = EBM.DoB;
            
            if(EBM.formFile != null)
            {
                var file = Path.Combine(_environment.ContentRootPath, "wwwroot/uploads", EBM.formFile.FileName);
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await EBM.formFile.CopyToAsync(fileStream);
                }
                intern.image_path = "~/uploads/" + EBM.formFile.FileName;
            }
            await _context.SaveChangesAsync();
        }

    }
}
