using Microsoft.EntityFrameworkCore;
using Sibolga_Library.Data;
using Sibolga_Library.Helper;
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

        public async Task<bool> CreatePeminjamanAsync(Peminjaman data)
        {
            _context.Add(data);
            await _context.SaveChangesAsync();
            return true;  
        }

        public async Task<bool> GetPeminjamanId(Peminjaman data)
        {
            string[] id = await _context.Peminjaman.Select(x => x.Id).ToArrayAsync();

            BuatPrimary.PrimaryPeminjaman(data, id);

            return true;
        }

        public List<Peminjaman> peminjaman()
        {
            return _context.Peminjaman.ToList();
        }
    }
}
