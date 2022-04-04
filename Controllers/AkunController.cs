using Microsoft.AspNetCore.Mvc;
using Sibolga_Library.Data;
using Sibolga_Library.Helper;
using Sibolga_Library.Models;
using Sibolga_Library.Services.AkunService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Controllers
{
    public class AkunController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IAkunService _service;

        public AkunController(AppDbContext db, IAkunService service)
        {
            _context = db;
            _service = service;
        }

        public IActionResult Index()
        {
            GabungModel Models = new GabungModel();

            return View(Models);
        }

        [HttpPost]
        public IActionResult DaftarUser(GabungModel gabungModel)
        {
            if(ModelState.IsValid)
            {
                _service.CreateUser(gabungModel);

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DaftarPemasok(GabungModel gabungModel)
        {
            if (ModelState.IsValid)
            {
                _service.CreatePemasok(gabungModel);

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
