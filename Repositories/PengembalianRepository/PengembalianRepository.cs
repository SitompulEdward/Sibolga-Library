using Sibolga_Library.Data;
using Sibolga_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Repositories.PengembalianRepository
{
    public class PengembalianRepository : IPengembalianRepository
    {
        private readonly AppDbContext _context;
        public PengembalianRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Pengembalian> pengembalian()
        {
            return _context.Pengembalian.ToList();
        }
    }
}
