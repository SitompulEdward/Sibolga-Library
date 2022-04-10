using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sibolga_Library.Data;
using Sibolga_Library.Helper;
using Sibolga_Library.Models;
using Sibolga_Library.Services;
using Sibolga_Library.Services.AkunService;
using Sibolga_Library.Services.BukuService;
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
        private readonly IBukuService _bukuService;
        private readonly IAkunService _service;
        private readonly EmailService _email;
        private static int _OTP;
        public AkunController(AppDbContext db, IAkunService service, EmailService email,IBukuService buku)
        {
            _bukuService = buku;
            _context = db;
            _service = service;
            _email = email;
        }

        public IActionResult Index()
        {
            GabungModel Models = new GabungModel();
            Models.buku = _bukuService.buku();

            return View(Models);
        }

        [HttpPost]
        public string KirimEmailOTP(string tujuanEmail)
        {
            var cariEmail = _context.Akses_Login.Where(x => x.Email == tujuanEmail).FirstOrDefault();

            if(cariEmail != null)
            {
                return "Email Tersebut Sudah di Gunakan !!!";
            }

            BuatOTP _bantu = new();
            _OTP = _bantu.OTP();

            string subjek = "Konfirmasi Email untuk Daftar Akun";

            string isiEmail = "<h1> Berikut Kode OTP Anda <i style='color:blue;'>"
                + _OTP.ToString() +"<i/><h1/>";

            bool cek = _email.SendEmail(tujuanEmail, subjek, isiEmail);

            if (cek)
            {
                return "Kode OTP berhasil di kirim ke " + tujuanEmail;
            }

            return "Email " + tujuanEmail + " tidak ditemukan";

        }

        [HttpPost]
        public IActionResult DaftarUser(GabungModel gabungModel, IFormFile image, int otp)
        {
            if(ModelState.IsValid)
            {
                if(_OTP == otp)
                {
                    _service.CreateUser(gabungModel, image);
                    _service.createAksesLoginUser(gabungModel);

                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DaftarPemasok(GabungModel gabungModel, IFormFile image, int otp)
        {
            if (ModelState.IsValid)
            {
                if (_OTP == otp)
                {
                    _service.CreatePemasok(gabungModel, image);
                    _service.createAksesLoginPemasok(gabungModel);

                    return RedirectToAction("Index");
                }
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
                        new Claim("Role", cariEmail.Roles.Name)
                    };

                    await HttpContext.SignInAsync(
                        new ClaimsPrincipal(
                            new ClaimsIdentity(daftar, "Cookie", "Email", "Role")
                        )
                    );

                    if(cariEmail.Roles.Id == "1")
                    {
                        return Redirect("/admin/home"); 
                    }
                    else if (cariEmail.Roles.Id == "2")
                    {
                        return Redirect("/pemasok/home");
                    }
                    else if(cariEmail.Roles.Id == "3")
                    {
                        return Redirect("/user/home");
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

        public IActionResult BukuView()
        {
            GabungModel Models = new GabungModel();
            Models.buku = _bukuService.buku();
            
            return View(Models);
        }
    }
}
