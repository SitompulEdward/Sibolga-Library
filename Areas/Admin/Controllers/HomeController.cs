using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Areas.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        [Area("Admin")]


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Daftar()
        {
            return View();
        }
    }
}
