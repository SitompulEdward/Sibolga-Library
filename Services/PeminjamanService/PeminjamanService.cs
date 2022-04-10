using Sibolga_Library.Models;
using Sibolga_Library.Repositories.PeminjamanRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Services.PeminjamanService
{
    public class PeminjamanService : IPeminjamanService
    {
        private readonly IPeminjamanRepository _repo;
        public PeminjamanService(IPeminjamanRepository repo)
        {
            _repo = repo;
        }

        public bool CreatePeminjaman(Peminjaman data)
        {
            _repo.GetPeminjamanId(data);
            data.Tgl_Peminjaman = DateTime.Now;

            return _repo.CreatePeminjamanAsync(data).Result;
        }

        public List<Peminjaman> peminjaman()
        {
            return _repo.peminjaman();
        }
    }

}
