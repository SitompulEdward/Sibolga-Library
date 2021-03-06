using Microsoft.EntityFrameworkCore;
using Sibolga_Library.Data;
using Sibolga_Library.Helper;
using Sibolga_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Repositories.BukuRepository
{
    public class BukuRepository : IBukuRepository
    {
        private readonly AppDbContext _context;

        public BukuRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Buku> buku()
        {
            return _context.Buku.ToList();
        }


        public async Task<bool> CreateBukuAsync(Buku buku)
        {
            _context.Add(buku);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteBuku(string id)
        {
            var cari = await _context.Buku.FirstOrDefaultAsync(x => x.Id == id);

            _context.Remove(cari);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> GetBukuId(Buku buku)
        {
            string[] id = await _context.Buku.Select(x => x.Id).ToArrayAsync();

            BuatPrimary.PrimaryBuku(buku,id);

            return true;
        }

        public async Task<Buku> SelectBukuId(string id)
        {
            return await _context.Buku.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateBukuAsync(Buku buku)
        {
            _context.Buku.Update(buku);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
