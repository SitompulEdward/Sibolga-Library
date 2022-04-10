using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sibolga_Library.Data;
using Sibolga_Library.Models;
using Sibolga_Library.Services.BukuService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class BukuController : Controller
    {
        private readonly IBukuService _service;
        private readonly AppDbContext _context;
        public BukuController(AppDbContext context, IBukuService service)
        {
            _context = context;
            _service = service;
        }
        public IActionResult Index()
        {
            var data = _service.buku();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult create(Buku data, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                _service.CreateBuku(data,image);

                return RedirectToAction("Index");
            }

            return View(data);
        }

        public async Task<IActionResult> Detail(string id)
        {
            var cari = await _service.Detail(id);

            if (cari == null)
            {
                return NotFound();
            }

            var data = new GabungModel();

            data.buku = await _context.Buku.Where(x => x.Id == id).ToListAsync();


            return View(data);

        }

        public async Task<IActionResult> Ubah(string id)
        {
            var cari = await _service.Detail(id);

            if (cari == null)
            {
                return NotFound();
            }

            return View(cari);
        }

        [HttpPost]
        public async Task<IActionResult> Ubah(Buku data)
        {
            if (ModelState.IsValid)
            {
                try 
                {
                   await _service.UpdateBuku(data);
                }
                catch
                {
                    return NotFound();
                }

                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteBuku(id);

            return RedirectToAction("Index");
        }
    }
}
