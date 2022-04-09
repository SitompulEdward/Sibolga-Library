using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sibolga_Library.Services.PengembalianService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class PengembalianController : Controller
    {
        private readonly IPengembalianService _service;
        public PengembalianController(IPengembalianService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var data = _service.pengembalian();
            return View(data);
        }
    }
}
