using Microsoft.EntityFrameworkCore;
using Sibolga_Library.Data;
using Sibolga_Library.Helper;
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

        public async Task<bool> CreatePengembalianAsync(Pengembalian data)
        {
            _context.Add(data);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> GetPengembalianId(Pengembalian data)
        {
            string[] id = await _context.Pengembalian.Select(x => x.Id).ToArrayAsync();

            BuatPrimary.PrimaryPengembalian(data, id);

            return true;
        }

        public List<Pengembalian> pengembalian()
        {
            return _context.Pengembalian.ToList();
        }
    }
}
