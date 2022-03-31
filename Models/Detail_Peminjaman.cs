using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Models
{
    public class Detail_Peminjaman
    {
        [Key]
        public int No { get; set; }
        public string PeminjamanId { get; set; }
        public string BukuId { get; set; }
        public int Jumlah_Buku { get; set; }

        [ForeignKey("PeminjamanId")]
        public Peminjaman FkPeminjaman { get; set; }
        [ForeignKey("BukuId")]
        public Buku FkBuku { get; set; }
    }
}
