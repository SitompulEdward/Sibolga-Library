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
    }
}
