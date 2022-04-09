using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sibolga_Library.Services.PeminjamanService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class PeminjamanController : Controller
    {
        private readonly IPeminjamanService _service;
        public PeminjamanController(IPeminjamanService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var data = _service.peminjaman();
            
            return View(data);
        }
    }
}
