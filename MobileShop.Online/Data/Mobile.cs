using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileShop.Online.Data
{
    public class Mobile
    {
        public int Id { get; set; }
        public string MobileName { get; set; }
        public string MobileVersion { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }
        public string Language { get; set; }
        public DateTime? CreateOn { get; set; }
        public DateTime? UpdateOn { get; set; }
    }
}
