using Microsoft.EntityFrameworkCore;
using Sibolga_Library.Data;
using Sibolga_Library.Helper;
using Sibolga_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Repositories.AdminRepository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _context;
        public AdminRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> GetAdminId(Admin admin)
        {
            string[] Id = await _context.Admin.Select(x => x.Admin_Id).ToArrayAsync();
            BuatPrimary.PrimaryAdmin(admin, Id);

            return true;
        }

        public async Task<Roles> GetRolesAdmin()
        {
            return await _context.Roles.Where(x => x.Id == "1").FirstOrDefaultAsync();
        }

        public async Task<bool> BuatAdminAsync(Admin data)
        {
            _context.Add(data);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> BuatAksesLogin(AksesLogin data)
        {
            _context.Add(data);
            await _context.SaveChangesAsync();

            return true;
        }

        public List<Buku> buku()
        {
            return _context.Buku.ToList();
        }

        public List<Pemasok> pemasok()
        {
            return _context.Pemasok.ToList();
        }

        public List<Peminjaman> peminjaman()
        {
            return _context.Peminjaman.ToList();
        }

        public List<Pengembalian> pengembalian()
        {
            return _context.Pengembalian.ToList();
        }

        public List<Admin> admin()
        {
            return _context.Admin.ToList();
        }

        public async Task<Admin> SelectAdminId(string id)
        {
            return await _context.Admin.FirstOrDefaultAsync(x => x.Admin_Id == id);
        }

        public async Task<bool> UpdateAdmin(Admin data)
        {
            _context.Admin.Update(data);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAdmin(string id)
        {
            var cari = await _context.Admin.FirstOrDefaultAsync(x => x.Admin_Id == id);

            _context.Remove(cari);
            await _context.SaveChangesAsync();
            
            return true;
        }
    }
}
