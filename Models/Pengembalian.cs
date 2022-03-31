using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Models
{
    public class Pengembalian
    {
        [Key]
        public string Id { get; set; }
        public DateTime Tgl_Pengembalian { get; set; }
        public string PeminjamanId { get; set; }
        public int Denda { get; set; }

        [ForeignKey("PeminjamanId")]
        public Peminjaman FkPeminjaman { get; set; }
    }
}
