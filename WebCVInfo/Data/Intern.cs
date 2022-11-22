using System.Collections.Generic;

namespace WebCVInfo.Data
{
    public class Intern
    {
        public int InternId { get; set; }
        public string Name { get; set; }
        public string DOB { get; set; }
        public string gender { get; set; }
        public string image_path { get; set; }
        public ICollection<Skill> Skills { get; set; }
    }
}
