using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Models
{
    public class Peminjaman
    {
        [Key]
        public string Id { get; set; }
        public string User_Id { get; set; }
        public DateTime Tgl_Peminjaman { get; set; }
        public DateTime Jatuh_Tempo { get; set; }

        [ForeignKey("User_Id")]
        public User FkUserId { get; set; }
    }
}
