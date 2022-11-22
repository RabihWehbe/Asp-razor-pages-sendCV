using System.Collections.Generic;

namespace WebCVInfo.Models
{
    public class InternView
    {
        public int InternID { get; set; }
        public string InternName { get; set; }
        public string Gender { get; set; }
        public string path_image { get; set; }

        public ICollection <Item> Items { get; set; }
        
        public class Item
        {
            public int ID { get; set; }
            public string ItemName { get; set; }
        }
    }
}
