using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sibolga_Library.Services.PemasokService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class PemasokController : Controller
    {
        private readonly IPemasokService _service;
        public PemasokController(IPemasokService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var data = _service.pemasok();

            return View(data);
        }


    }
}
