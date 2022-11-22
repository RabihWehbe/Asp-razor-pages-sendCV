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
    public class GetInternService
    {
        public AppDBContext _appDBContext { get; set; }


        public GetInternService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        
        public async Task<InternView> getIntern(string name)
        {
            return await _appDBContext.Interns
                .Where(x => x.Name == name)
                .Select(x => new InternView
                {
                    InternID = x.InternId,
                    InternName = x.Name,
                    path_image = x.image_path,
                    Gender = x.gender,
                    Items = (ICollection<InternView.Item>)x.Skills
                    .Select(j => new InternView.Item
                    {
                        ID = j.SkillId,
                        ItemName = j.SName
                    })
                }).SingleOrDefaultAsync();
        }


    }
}
