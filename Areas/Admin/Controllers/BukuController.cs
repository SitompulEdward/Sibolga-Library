using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public BukuController(IBukuService service)
        {
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
    }
}
