using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sibolga_Library.Services.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _service;
        public UserController(IUserService user)
        {
            _service = user;
        }
        public IActionResult Index()
        {
            var data = _service.user();

            return View(data);
        }
    }
}
