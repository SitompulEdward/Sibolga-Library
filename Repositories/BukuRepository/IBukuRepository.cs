using Sibolga_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Repositories.BukuRepository
{
    public interface IBukuRepository
    {
        List<Buku> buku();
        Task<bool> GetBukuId(Buku buku);
        Task<bool> CreateBukuAsync(Buku buku);
        Task<Buku> SelectBukuId(string id);
        Task<bool> UpdateBukuAsync(Buku buku);
        Task<bool> DeleteBuku(string id);
    }
}
