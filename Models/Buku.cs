using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Models
{
    public class Buku
    {
        [Key]
        public string Id { get; set; }
        public string Judul_Buku { get; set; }
        public string Pengarang { get; set; }
        public string Penerbit { get; set; }
        public string Tahun_Terbit { get; set; }
        public int Stock { get; set; }
        public string Pemasok_Id { get; set; }
        public string Gambar { get; set; }
        public string Sipnosis { get; set; }

        [ForeignKey("Pemasok_Id")]
        public Pemasok FkPemasokId { get; set; }
    }
}
