using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebCVInfo.Data;
using WebCVInfo.Models;

namespace WebCVInfo
{
    public class CheckService
    {
        public AppDBContext _context { get; set; }

        public CheckService(AppDBContext context)
        {
            _context = context;
        }
    }
}
