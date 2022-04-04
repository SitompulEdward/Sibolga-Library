using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sibolga_Library.Data;
using Sibolga_Library.Helper;
using Sibolga_Library.Models;
using Sibolga_Library.Services.AkunService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        public IActionResult DaftarUser(GabungModel gabungModel, IFormFile image)
        {
            if(ModelState.IsValid)
            {
                _service.CreateUser(gabungModel,image);
                _service.createAksesLoginUser(gabungModel);

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DaftarPemasok(GabungModel gabungModel, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                _service.CreatePemasok(gabungModel,image);
                _service.createAksesLoginPemasok(gabungModel);

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Login(GabungModel gabungModel)
        {
            var data = new AksesLogin()
            {
                Email = gabungModel.login.Email,
                Password = gabungModel.login.Password
            };

            var cariEmail = _context.Akses_Login.Where(x => x.Email == data.Email).FirstOrDefault();

            if (cariEmail != null)
            {
                var cekPassword = _context.Akses_Login.Where(x => x.Email == data.Email
                                                            && x.Password == data.Password)
                                                            .Include(y => y.Roles).FirstOrDefault();

                if(cekPassword != null)
                {
                    var daftar = new List<Claim>
                    {
                        new Claim("Email", cariEmail.Email),
                        new Claim("Password", cariEmail.Roles.Name)
                    };

                    await HttpContext.SignInAsync(
                        new ClaimsPrincipal(
                            new ClaimsIdentity(daftar, "Cookie", "Email", "Roles")
                        )
                    );

                    if(cariEmail.Roles.Id == "1")
                    {
                        return Redirect("/Admin/Home"); 
                    }
                    else if (cariEmail.Roles.Id == "2")
                    {
                        return Redirect("/Pemasok/Home");
                    }
                    else if(cariEmail.Roles.Id == "3")
                    {
                        return Redirect("/User/Home");
                    }

                    return RedirectToAction(controllerName: "Akun", actionName: "Index");
                }

                ViewBag.pesan = "Password Salah !!!";
            }
            ViewBag.pesan = "Email Salah !!!";
            
            return RedirectToAction(controllerName: "Akun", actionName: "Index");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return Redirect("/");
        }
    }
}
