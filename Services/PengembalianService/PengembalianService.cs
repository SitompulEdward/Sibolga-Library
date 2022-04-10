using Sibolga_Library.Models;
using Sibolga_Library.Repositories.PengembalianRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Services.PengembalianService
{
    public class PengembalianService : IPengembalianService
    {
        private readonly IPengembalianRepository _repo;
        public PengembalianService(IPengembalianRepository repo)
        {
            _repo = repo;
        }

        public Task<bool> CreatePengembalian(Pengembalian data)
        {
            _repo.GetPengembalianId(data);
            
            return _repo.CreatePengembalianAsync(data);
        }

        public List<Pengembalian> pengembalian()
        {
            return _repo.pengembalian();
        }
    }
}
