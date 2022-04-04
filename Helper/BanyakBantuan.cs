using Sibolga_Library.Data;
using Sibolga_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Helper
{
    public static class BanyakBantuan
    {
        public static Object BuatUser(GabungModel gabungModel)
        {
            var user = new User()
            {
                Nama_Lengkap = gabungModel.user.Nama_Lengkap,
                Email = gabungModel.user.Email,
                Password = gabungModel.user.Password,
                Alamat = gabungModel.user.Alamat,
                No_Telp = gabungModel.user.No_Telp
            };
            
            return user;
        }

        public static Object BuatPemasok(GabungModel gabungModel)
        {
            var pemasok = new Pemasok()
            {
                Nama_Lengkap = gabungModel.pemasok.Nama_Lengkap,
                Email = gabungModel.pemasok.Email,
                Password = gabungModel.pemasok.Password,
                Alamat = gabungModel.pemasok.Alamat,
                No_Telp = gabungModel.pemasok.No_Telp
            };

            return pemasok;
        }
    }
}
