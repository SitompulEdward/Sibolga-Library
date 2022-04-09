using Microsoft.AspNetCore.Http;
using Sibolga_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Services.AdminService
{
    public interface IAdminService
    {
        List<Buku> buku();
        List<Pemasok> pemasok();
        List<Peminjaman> peminjaman();
        List<Pengembalian> pengembalian();
        List<Admin> admins();
        bool CreateAdmin(Admin admin, IFormFile file);
        bool createAksesLoginAdmin(Admin data);
    }
}
