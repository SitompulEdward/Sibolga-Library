using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sibolga_Library.Models;
using Sibolga_Library.Services.BukuService;
using Sibolga_Library.Services.PeminjamanService;
using Sibolga_Library.Services.PengembalianService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly IBukuService _bukuService;
        private readonly IPeminjamanService _pservice;
        private readonly IPengembalianService _PengService;
        public HomeController(IBukuService buku, IPeminjamanService peminjaman, IPengembalianService pengembalian)
        {
            _PengService = pengembalian;
            _pservice = peminjaman;
            _bukuService = buku;
        }
        public IActionResult Index()
        {
            GabungModel data = new GabungModel();

            data.buku = _bukuService.buku();

            return View(data);
        }

        public IActionResult SemuaBuku()
        {
            GabungModel data = new GabungModel();

            data.buku = _bukuService.buku();

            return View(data);
        }

        public IActionResult Pinjam()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Pinjam(Peminjaman data)
        {
            if (ModelState.IsValid)
            {
                _pservice.CreatePeminjaman(data);

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Pengembalian()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Pengembalian(Pengembalian data)
        {
            if (ModelState.IsValid)
            {
               await _PengService.CreatePengembalian(data);

                return RedirectToAction("Index");
            }
            return View(data);
        }
        public IActionResult Detail()
        {
            return View();
        }
    }
}
