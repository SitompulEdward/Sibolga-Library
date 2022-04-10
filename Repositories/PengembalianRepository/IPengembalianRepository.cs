using Sibolga_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Repositories.PengembalianRepository
{
    public interface IPengembalianRepository
    {
        List<Pengembalian> pengembalian();
        Task<bool> CreatePengembalianAsync(Pengembalian data);
        Task<bool> GetPengembalianId(Pengembalian data);
    }
}
