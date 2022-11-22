using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCVInfo.Data
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string SName { get; set; }
        public ICollection<Intern> Interns { get; set; }

        public static explicit operator Skill(List<string> v)
        {
            throw new NotImplementedException();
        }
    }
}
