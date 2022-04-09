using Microsoft.AspNetCore.Http;
using Sibolga_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Services.BukuService
{
    public interface IBukuService
    {
        List<Buku> buku();
        bool CreateBuku(Buku data, IFormFile file);
    }
}
