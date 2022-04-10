using Sibolga_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Repositories.AdminRepository
{
    public interface IAdminRepository
    {
        Task<bool> GetAdminId(Admin admin);
        Task<bool> BuatAdminAsync(Admin data);
        Task<Roles> GetRolesAdmin();
        Task<bool> BuatAksesLogin(AksesLogin data);
        List<Buku> buku();
        List<Pemasok> pemasok();
        List<Peminjaman> peminjaman();
        List<Pengembalian> pengembalian();
        List<Admin> admin();
        Task<Admin> SelectAdminId(string id);
        Task<bool> UpdateAdmin(Admin data);
        Task<bool> DeleteAdmin(string id);
    }
}
