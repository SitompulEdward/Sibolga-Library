using Sibolga_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Helper
{
    public class BuatPrimary
    {
       public static string Primary(GabungModel gabungModel, string[] Id)
        {

            int temp;
            foreach (var ids in Id)
            {
                temp = Int32.Parse(ids.Split("-00")[1]);
                var usId = "US-00" + (temp + 1);

                gabungModel.user.User_Id = usId;
            }

            if (gabungModel.user.User_Id == null)
            {
                gabungModel.user.User_Id = "US-001";
            }

            return gabungModel.user.User_Id;
        }

        public static string PrimaryPemasok(GabungModel gabungModel, string[] Id)
        {
            int temp;
            foreach (var ids in Id)
            {
                temp = Int32.Parse(ids.Split("-00")[1]);
                var psId = "PS-00" + (temp + 1);

                gabungModel.pemasok.Pemasok_Id = psId;
            }

            if (gabungModel.pemasok.Pemasok_Id == null)
            {
                gabungModel.pemasok.Pemasok_Id = "PS-001";
            }

            return gabungModel.pemasok.Pemasok_Id;
        }

        public static string PrimaryAdmin(Admin admin, string[] Id)
        {
            int temp;
            foreach (var ids in Id)
            {
                temp = Int32.Parse(ids.Split("-00")[1]);
                var psId = "AD-00" + (temp + 1);

                admin.Admin_Id = psId;
            }

            if (admin.Admin_Id == null)
            {
                admin.Admin_Id = "AD-001";
            }

            return admin.Admin_Id;
        }

        public static string PrimaryBuku(Buku buku, string[] Id)
        {
            int temp;
            foreach (var ids in Id)
            {
                temp = Int32.Parse(ids.Split("-00")[1]);
                var psId = "BK-00" + (temp +  1);

                buku.Id = psId;
            }

            if (buku.Id == null)
            {
                buku.Id = "BK-001";
            }

            return buku.Id;
        }

        public static string PrimaryPeminjaman(Peminjaman data, string[] Id)
        {
            int temp;
            foreach (var ids in Id)
            {
                temp = Int32.Parse(ids.Split("-00")[1]);
                var psId = "PJ-00" + (temp + 1);

                data.Id = psId;
            }

            if (data.Id == null)
            {
                data.Id = "PJ-001";
            }

            return data.Id;
        }

        public static string PrimaryPengembalian(Pengembalian data, string[] Id)
        {
            int temp;
            foreach (var ids in Id)
            {
                temp = Int32.Parse(ids.Split("-00")[1]);
                var psId = "PG-00" + (temp + 1);

                data.Id = psId;
            }

            if (data.Id == null)
            {
                data.Id = "PG-001";
            }

            return data.Id;
        }
    }
}
