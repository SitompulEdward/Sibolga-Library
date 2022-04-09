using Microsoft.AspNetCore.Http;
using Sibolga_Library.Models;
using Sibolga_Library.Repositories.AdminRepository;
using Sibolga_Library.Services.AkunService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Services.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly FileService _file;
        private readonly IAdminRepository _adRepo;

        public AdminService(FileService file,IAdminRepository repo)
        {
            _file = file;
            _adRepo = repo;
        }

        public List<Admin> admins()
        {
            return _adRepo.admin();
        }

        public List<Buku> buku()
        {
            return _adRepo.buku();
        }

        public bool CreateAdmin(Admin admin, IFormFile file)
        {
            _adRepo.GetAdminId(admin);

            admin.Gambar = _file.SimpanFile(file).Result;
            var role = "1";
            admin.RolesId = role;

            return _adRepo.BuatAdminAsync(admin).Result;
        }

        public bool createAksesLoginAdmin(Admin data)
        {
            Roles role = _adRepo.GetRolesAdmin().Result;

            var akses = new AksesLogin()
            {
                Email = data.Email,
                Password = data.Password,
                Roles = role
            };

            return _adRepo.BuatAksesLogin(akses).Result;
        }

        public List<Pemasok> pemasok()
        {
            return _adRepo.pemasok();
        }

        public List<Peminjaman> peminjaman()
        {
            return _adRepo.peminjaman();
        }

        public List<Pengembalian> pengembalian()
        {
            return _adRepo.pengembalian();
        }
    }
}
