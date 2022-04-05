using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Areas.Pemasok.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        [Area("Pemasok")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
