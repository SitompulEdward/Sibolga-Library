using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Models
{
    public class Pembayaran
    {
        [Key]
        public int No { get; set; }
        public string PeminjamanId { get; set; }
        public string Status { get; set; }
        public int Total_Bayar { get; set; }
        
        [ForeignKey("PeminjamanId")]
        public Peminjaman FkPeminjaman { get; set; }
    }
}
