using Sibolga_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Services.PeminjamanService
{
    public interface IPeminjamanService
    {
        List<Peminjaman> peminjaman();
        bool CreatePeminjaman(Peminjaman data);
    }
}
