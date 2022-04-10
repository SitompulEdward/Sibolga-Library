using Sibolga_Library.Models;
using Sibolga_Library.Repositories.PemasokRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Services.PemasokService
{
    public class PemasokService : IPemasokService
    {
        private readonly IPemasokRepository _repo;
        public PemasokService(IPemasokRepository repo)
        {
            _repo = repo;
        }
        public List<Pemasok> pemasok()
        {
            return _repo.pemasok();
        }
    }
}
