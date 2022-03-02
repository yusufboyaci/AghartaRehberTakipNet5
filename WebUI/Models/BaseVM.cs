using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public abstract class BaseVM
    {
        public int Id { get; set; }

        public bool IsActive { get; set; }
    }
}
