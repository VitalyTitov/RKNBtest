using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RKNBtest.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Currency> Currencies { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
