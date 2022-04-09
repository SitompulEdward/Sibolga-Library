using Microsoft.AspNetCore.Http;
using Sibolga_Library.Models;
using Sibolga_Library.Repositories.BukuRepository;
using Sibolga_Library.Services.AkunService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Services.BukuService
{
    public class BukuService : IBukuService
    {
        private readonly IBukuRepository _repo;
        private readonly FileService _file;
        public BukuService(IBukuRepository repo, FileService file)
        {
            _file = file;
            _repo = repo;
        }
        public List<Buku> buku()
        {
            return _repo.buku();
        }

        public bool CreateBuku(Buku data, IFormFile file)
        {
            _repo.GetBukuId(data);

            data.Gambar = _file.SimpanFile(file).Result;

            return _repo.CreateBukuAsync(data).Result;
        }
    }

}
