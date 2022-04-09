using Sibolga_Library.Data;
using Sibolga_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Repositories.PeminjamanRepository
{
    public class PeminjamanRepository : IPeminjamanRepository
    {
        private readonly AppDbContext _context;
        public PeminjamanRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Peminjaman> peminjaman()
        {
            return _context.Peminjaman.ToList();
        }
    }
}
