using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using WebCVInfo.Data;
using WebCVInfo.Models;

namespace WebCVInfo
{
    public class BrowseInternsService
    {
        AppDBContext _context { get; set; }

        public BrowseInternsService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<InternView>> BrowseInterns()
        {
            return await _context.Interns
                .Select(r => new InternView
                {
                    InternName = r.Name,
                    InternID = r.InternId,
                    Gender = r.gender,
                    path_image = r.image_path
                }).ToListAsync();
        }
    }
}
