using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class AdresDefteriVM : BaseVM
    {
        public string Adres { get; set; }
        public string Mail { get; set; }
        public string Konum { get; set; }
        public int KisiId { get; set; }
    }
}
