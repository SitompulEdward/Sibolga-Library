using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sibolga_Library.Data;
using Sibolga_Library.Models;
using Sibolga_Library.Services.BukuService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Areas.Pemasok.Controllers
{
    [Authorize(Roles = "Pemasok")]
    [Area("Pemasok")]
    public class HomeController : Controller
    {
        private readonly IBukuService _bukuService;
        private readonly AppDbContext _context;
        public HomeController(IBukuService buku, AppDbContext context)
        {
            _bukuService = buku;
            _context = context;
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
        public IActionResult CreateBuku()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBuku(Buku data, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                _bukuService.CreateBuku(data, image);

                return RedirectToAction("Index");
            }

            return View(data);
        }
    }
}
