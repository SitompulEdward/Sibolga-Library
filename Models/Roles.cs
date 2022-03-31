using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Models
{
    public class Roles
    {
        [Key]
        public String Id { get; set; }
        public string Name { get; set; }
    }
}
