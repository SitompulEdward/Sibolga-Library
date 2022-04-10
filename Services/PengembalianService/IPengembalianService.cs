using Sibolga_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Services.PengembalianService
{
    public interface IPengembalianService
    {
        List<Pengembalian> pengembalian();
        Task<bool> CreatePengembalian(Pengembalian data);
    }
}
