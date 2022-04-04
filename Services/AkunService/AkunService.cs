using Sibolga_Library.Helper;
using Sibolga_Library.Models;
using Sibolga_Library.Repositories.AkunRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Services.AkunService
{
    public class AkunService : IAkunService
    {
        private readonly IAkunRepository _akunRepo;
        public AkunService(IAkunRepository repo)
        {
            _akunRepo = repo;
        }

        public bool CreatePemasok(GabungModel gabungModel)
        {
            var ambilData = BanyakBantuan.BuatPemasok(gabungModel);

            _akunRepo.GetPemasokId(gabungModel);

            var role = "2";
            gabungModel.pemasok.RolesId = role;

            return _akunRepo.BuatPemasokAsync(gabungModel.pemasok).Result;
        }

        public bool CreateUser(GabungModel gabungModel)
        {
            var ambilData = BanyakBantuan.BuatUser(gabungModel);

            _akunRepo.GetUserId(gabungModel);

            var role = "3";
            gabungModel.user.RolesId = role;

            return _akunRepo.BuatUserAysnc(gabungModel.user).Result;
        }
    }
}
