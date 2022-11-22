using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCVInfo.Data;
using System.IO;
using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace WebCVInfo
{
    public class DeleteService
    {
        public AppDBContext _context { get; set; }

        public DeleteService(AppDBContext context)
        {
            _context = context;
        }

        public async Task DeleteIntern(int id)
        {
            //find can find the entity and hence we can modify it
            //but if this entity contains a set of values then it may initialize this set to null so we have to get them manually
            Intern i = await _context.Interns.Where(r => r.InternId == id)
                .Select(r => new Intern
                {
                    image_path = r.image_path,
                    Skills = (ICollection<Skill>)r.Skills.Select(x => new Skill
                    {
                        SkillId = x.SkillId,
                        SName = x.SName
                    })
                }).SingleOrDefaultAsync();

            DeleteImage(i.image_path);
            _context.Skills.RemoveRange(i.Skills);

            await _context.SaveChangesAsync();

            var intern = await _context.Interns.FindAsync(id);
            if(intern == null)
            {
                return;
            }
            _context.Interns.Remove(intern);
            await _context.SaveChangesAsync();
        }



        public void DeleteImage(string image_path)
        {
            //I have to modify the path since if I want to delete a file(image)
            //the system must read the correct name of the directory under Project Folder
            string[] PathPartial = image_path.Split('~');

            string path = @"wwwroot" + PathPartial[1];

            File.Delete(path);
        }
    }
}
