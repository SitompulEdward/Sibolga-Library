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
        public List<Buku> buku { get; set; }
        public GabungModel()
        {
            buku = new List<Buku>();
        }
    }

    public class GabungView
    {
        public List<Buku> buku { get; set; }
        public List<Pemasok> pemasok { get; set; }
        public List<Peminjaman> peminjaman { get; set; }
        public List<Pengembalian> pengembalian { get; set; }

        public GabungView()
        {
            buku = new List<Buku>();
            pemasok = new List<Pemasok>();
            peminjaman = new List<Peminjaman>();
            pengembalian = new List<Pengembalian>();
        }
    }


}
