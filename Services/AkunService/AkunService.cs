using Microsoft.AspNetCore.Http;
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
        private readonly FileService _file;
        public AkunService(IAkunRepository repo, FileService file)
        {
            _akunRepo = repo;
            _file = file;
        }

        

        public bool CreatePemasok(GabungModel gabungModel, IFormFile file)
        {
            BanyakBantuan.BuatPemasok(gabungModel);

            _akunRepo.GetPemasokId(gabungModel);

            gabungModel.pemasok.Gambar = _file.SimpanFile(file).Result;

            return _akunRepo.BuatPemasokAsync(gabungModel.pemasok).Result;
        }

        public bool CreateUser(GabungModel gabungModel, IFormFile file)
        {
           BanyakBantuan.BuatUser(gabungModel);

            _akunRepo.GetUserId(gabungModel);

            gabungModel.user.Gambar = _file.SimpanFile(file).Result;

            var role = "3";
            gabungModel.user.RolesId = role;

            return _akunRepo.BuatUserAysnc(gabungModel.user).Result;
        }

        

        public bool createAksesLoginPemasok(GabungModel gabungModel)
        {
            Roles role = _akunRepo.GetRolesPemasok().Result;

            var akses = new AksesLogin()
            {
                Email = gabungModel.pemasok.Email,
                Password = gabungModel.pemasok.Password,
                Roles = role
            };

            return _akunRepo.BuatAksesLogin(akses).Result;
        }

        public bool createAksesLoginUser(GabungModel gabungModel)
        {
            Roles role = _akunRepo.GetRolesUser().Result;

            var akses = new AksesLogin()
            {
                Email = gabungModel.user.Email,
                Password = gabungModel.user.Password,
                Roles = role
            };

            return _akunRepo.BuatAksesLogin(akses).Result;
        }

       
    }
}
