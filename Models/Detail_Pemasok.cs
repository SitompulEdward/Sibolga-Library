using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Models
{
    public class Detail_Pemasok
    {
        [Key]
        public int No { get; set; }
        public string Pemasok_Id { get; set; }
        public int Jumlah_Poin { get; set; }

        [ForeignKey("Pemasok_Id")]
        public Pemasok FkPemasokId { get; set; }
    }
}
