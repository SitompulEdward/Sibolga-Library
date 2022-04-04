using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Models
{
    public class GabungModel
    {
        public User user { get; set; }
        public Pemasok pemasok { get; set; }
        public AksesLogin login { get; set; }
    }
}
