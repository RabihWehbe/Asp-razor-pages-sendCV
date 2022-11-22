using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebCVInfo.Data;
using WebCVInfo.Models;

namespace WebCVInfo
{
    public class SendCVService
    {
        public AppDBContext _context { get; set; }
        public SendCVService(AppDBContext context)
        {
            _context = context;
        }

        //to upload the image
        public async Task UploadImageAsync(IFormFile formFile, IHostEnvironment _environment)
        {
            var file = Path.Combine(_environment.ContentRootPath, "wwwroot/uploads", formFile.FileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await formFile.CopyToAsync(fileStream);
            }
            return;
        }

        public async Task<int> AddRecord(InfoBindingModel ibm, List<string> skills)
        {
            List<Skill> items = new List<Skill>();
            
            foreach(var skill in skills)
            {
                items.Add(new Skill
                {
                    SName = skill
                });
            }

            var intern = new Intern
            {
                Name = ibm.Name,
                gender = ibm.gender,
                DOB = ibm.DoB,
                image_path = "~/uploads/" + ibm.formFile.FileName.ToString(),
                Skills = items
            };
            _context.Add(intern);
            await _context.SaveChangesAsync();

            return 1;
        }
    }
}
