using Sibolga_Library.Data;
using Sibolga_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Repositories.PemasokRepository
{
    public class PemasokRepository : IPemasokRepository
    {
        private readonly AppDbContext _context;
        public PemasokRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Pemasok> pemasok()
        {
            return _context.Pemasok.ToList();
        }
    }
}
