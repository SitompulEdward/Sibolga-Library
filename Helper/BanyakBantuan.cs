using Sibolga_Library.Data;
using Sibolga_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Helper
{
    public class BanyakBantuan
    {
        private readonly AppDbContext _context;
        public BanyakBantuan(AppDbContext context)
        {
            _context = context;
        }

        public static Object BuatUser(GabungModel gabungModel)
        {
            var roles = "3";
            var user = new User()
            {
                Nama_Lengkap = gabungModel.user.Nama_Lengkap,
                Email = gabungModel.user.Email,
                Password = gabungModel.user.Password,
                Alamat = gabungModel.user.Alamat,
                No_Telp = gabungModel.user.No_Telp,
                RolesId = roles
            };
            
            return user;
        }

        public static Object BuatPemasok(GabungModel gabungModel)
        {
            var roles = "2";
            var pemasok = new Pemasok()
            {
                Nama_Lengkap = gabungModel.pemasok.Nama_Lengkap,
                Email = gabungModel.pemasok.Email,
                Password = gabungModel.pemasok.Password,
                Alamat = gabungModel.pemasok.Alamat,
                No_Telp = gabungModel.pemasok.No_Telp,
                RolesId = roles
            };

            return pemasok;
        }

    }
}
