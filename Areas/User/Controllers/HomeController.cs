using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Areas.User.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "User")]
        [Area("User")]
        public IActionResult Index()
        {
            return View();
        }


    }
}
