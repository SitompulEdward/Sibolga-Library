using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Models
{
    public class Riwayat_Penarikan
    {
        [Key]
        public int No { get; set; }
        public string Email_Pemasok { get; set; }
        public int Jumlah_Poin { get; set; }
        public DateTime Tgl_Penarikan { get; set; }

        [ForeignKey("Email_Pemasok")]
        public Pemasok FkEmail { get; set; }
    }
}
