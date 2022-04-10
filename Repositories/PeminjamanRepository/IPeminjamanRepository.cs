using Sibolga_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Repositories.PeminjamanRepository
{
    public interface IPeminjamanRepository
    {
        List<Peminjaman> peminjaman();
        Task<bool> CreatePeminjamanAsync(Peminjaman data);
        Task<bool> GetPeminjamanId(Peminjaman data);
    }
}
